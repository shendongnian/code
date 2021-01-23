    using System;
    using System.Collections;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using System.Linq;
    namespace Waqas
    {
        internal class ClsPrint
        {
            #region Variables
            private int iCellHeight = 0; //Used to get/set the datagridview cell height
            private int iTotalWidth = 0; //
            private int iRow = 0; //Used as counter
            private bool bFirstPage = false; //Used to check whether we are printing first page
            private bool bNewPage = false; // Used to check whether we are printing a new page
            private int iHeaderHeight = 0; //Used for the header height
            private StringFormat strFormat; //Used to format the grid rows.
            private ArrayList arrColumnLefts = new ArrayList(); //Used to save left coordinates of columns
            private ArrayList arrColumnWidths = new ArrayList(); //Used to save column widths
            private PrintDocument _printDocument = new PrintDocument();
            private DataGridView gw = new DataGridView();
            private string _ReportHeader;
            #endregion
            public ClsPrint(DataGridView gridview, string ReportHeader)
            {
                _printDocument.DefaultPageSettings.Landscape = true;
                _printDocument.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
                _printDocument.DefaultPageSettings.Margins = new Margins(30, 30, 30, 30);
                //_printDocument.DefaultPageSettings.PaperSize.PaperName = "A4";
                _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
                _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
                gw = gridview;
                _ReportHeader = ReportHeader;
            }
            public void PrintForm()
            {
                //Open the print preview dialog
                PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
                objPPdialog.Document = _printDocument;
                objPPdialog.ShowIcon = false;
                objPPdialog.Text = "Print Preview";
                objPPdialog.WindowState = FormWindowState.Maximized;
                objPPdialog.ShowDialog();
            }
            private void _printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                //try
                //{
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in gw.Columns)
                    {
                        iTmpWidth = ((int) (Math.Floor((double) ((double) GridCol.Width/
                                                                (double) iTotalWidth*(double) iTotalWidth*
                                                                ((double) e.MarginBounds.Width/(double) iTotalWidth)))));
                        iHeaderHeight = (int) (e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 60;
                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= gw.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = gw.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 30;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(_ReportHeader,
                                new Font("Calibri Light", 20, FontStyle.Bold),
                                new SolidBrush(Color.Black), e.MarginBounds.Left,
                                e.MarginBounds.Top+20 - e.Graphics.MeasureString(_ReportHeader,
                                    new Font(gw.Font, FontStyle.Bold),
                                    e.MarginBounds.Width).Height - 13);
                            String strDate = DateTime.Now.ToString("dd-MMM-yy hh:mm tt");
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font("Calibri Light", 12, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left-20 +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                    new Font(gw.Font, FontStyle.Bold),
                                    e.MarginBounds.Width).Width),
                                e.MarginBounds.Top+30 - e.Graphics.MeasureString(_ReportHeader,
                                    new Font(new Font(gw.Font, FontStyle.Bold),
                                        FontStyle.Bold), e.MarginBounds.Width).Height - 13);
                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top+30;
                            DataGridViewColumn[] _GridCol = new DataGridViewColumn[gw.Columns.Count];
                            int colcount = 0;
                            //Convert ltr to rtl
                            foreach (DataGridViewColumn GridCol in gw.Columns)
                            {
                                _GridCol[colcount++] = GridCol;
                            }
                            for (int i =0;  i <= (_GridCol.Count() - 1); i++)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro),
                                    new Rectangle((int) arrColumnLefts[iCount], iTopMargin,
                                        (int) arrColumnWidths[iCount], iHeaderHeight));
                                e.Graphics.DrawRectangle(new Pen(Color.Black),
                                    new Rectangle((int) arrColumnLefts[iCount], iTopMargin,
                                        (int) arrColumnWidths[iCount], iHeaderHeight));
                                e.Graphics.DrawString(_GridCol[i].HeaderText,
                                    new Font("Calibri Light", 12, FontStyle.Bold),
                                    new SolidBrush(Color.Black),
                                    new RectangleF((int) arrColumnLefts[iCount], iTopMargin,
                                        (int) arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        DataGridViewCell[] _GridCell = new DataGridViewCell[GridRow.Cells.Count];
                        int cellcount = 0;
                        //Convert ltr to rtl
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            _GridCell[cellcount++] = Cel;
                        }
                        //Draw Columns Contents                
                        for (int i =0; i <=(_GridCell.Count() - 1); i++)
                        {
                            if (_GridCell[i].Value != null)
                            {
                                if (_GridCell[i].GetType() != typeof (DataGridViewImageCell))
                                {
                                    e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                                        new Font("Calibri Light", 10),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int) arrColumnLefts[iCount],
                                            (float) iTopMargin,
                                            (int) arrColumnWidths[iCount], (float) iCellHeight),
                                        strFormat);
                                }
                                else
                                {
                                    Image img = Common.byteArrayToImage((byte[]) _GridCell[i].Value);
                                    Rectangle m = new Rectangle((int) arrColumnLefts[iCount],iTopMargin,
                                                                (int) arrColumnWidths[iCount],  iCellHeight);
                                    if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // image is wider
                                    {
                                        m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
                                    }
                                    else
                                    {
                                        m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
                                    }
                                    e.Graphics.DrawImage(img, m);
                                }
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(new Pen(Color.Black),
                                new Rectangle((int) arrColumnLefts[iCount], iTopMargin,
                                    (int) arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
                //}
                //catch (Exception exc)
                //{
                //    KryptonMessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                //       MessageBoxIcon.Error);
                //}
            }
            private void _printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
            {
                try
                {
                    strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Center;
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Trimming = StringTrimming.EllipsisCharacter;
                    arrColumnLefts.Clear();
                    arrColumnWidths.Clear();
                    iCellHeight = 0;
                    iRow = 0;
                    bFirstPage = true;
                    bNewPage = true;
                    // Calculating Total Widths
                    iTotalWidth = 0;
                    foreach (DataGridViewColumn dgvGridCol in gw.Columns)
                    {
                        iTotalWidth += dgvGridCol.Width;
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public void PrintDocument(MemoryStream outputStream)
        {
            FlowDocument fd = new FlowDocument();
            TextRange tr = new TextRange(fd.ContentStart, fd.ContentEnd);
            tr.Load(outputStream, System.Windows.DataFormats.Rtf);
         
            PrintDialog printDlg = new PrintDialog();
            fd.PageHeight = printDlg.PrintableAreaHeight;
            fd.PageWidth = printDlg.PrintableAreaWidth;
            fd.PagePadding = new Thickness(25);
            
            fd.ColumnGap = 0;
            fd.ColumnWidth = (fd.PageWidth -
                                   fd.ColumnGap -
                                   fd.PagePadding.Left -
                                   fd.PagePadding.Right);
            if (printDlg.ShowDialog() == true)
            {              
                IDocumentPaginatorSource idpSource = fd;
                idpSource.DocumentPaginator.PageSize = new Size { Height = 600, Width = 600 };
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Printing Document");
            }
        }

        DataTable dtRangeName_Address = new DataTable();
        private void RnD_Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            btnUndo.Enabled = false;
            dtRangeName_Address.Columns.Add("Name");
            dtRangeName_Address.Columns.Add("Address");
        }
        private void btnFillColor_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet ws = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
            string strFilledRangeAddress = Globals.ThisAddIn.Application.Selection.Address.ToString();
            Excel.Range FilledRange = ws.get_Range(strFilledRangeAddress);
            FilledRange.Interior.Color = Color.YellowGreen;
            DataRow drRangeName_Address = dtRangeName_Address.NewRow();
            bool TagAlreadyExists = false;
            string tagName = Microsoft.VisualBasic.Interaction.InputBox("Enter tag name:");
            for (int i = dtRangeName_Address.Rows.Count - 1; i >= 0; i--)
            {
                if (dtRangeName_Address.Rows[i][0].ToString() == tagName)
                {
                    Excel.Range ExistingRange = ws.get_Range(dtRangeName_Address.Rows[i][1].ToString());
                    FilledRange = Globals.ThisAddIn.Application.Union(ExistingRange, FilledRange);
                    drRangeName_Address[1] = FilledRange.Address.ToString();
                    drRangeName_Address[0] = tagName;
                    TagAlreadyExists = true;
                    break;
                }
            }
            if (TagAlreadyExists == false)
            {
                drRangeName_Address[1] = strFilledRangeAddress;
                drRangeName_Address[0] = tagName;
            }
            FilledRange.Name = tagName;
            dtRangeName_Address.Rows.Add(drRangeName_Address);
            if (btnUndo.Enabled == false)
                btnUndo.Enabled = true;
        }
        private void btnUndo_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet ws = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
            Excel.Range FilledRange = ws.get_Range(dtRangeName_Address.Rows[dtRangeName_Address.Rows.Count - 1][1].ToString());
            string tagName = dtRangeName_Address.Rows[dtRangeName_Address.Rows.Count - 1][0].ToString();
            Excel.Range ExistingRange = null;
            bool TagAlreadyExists = false;
            for (int i = dtRangeName_Address.Rows.Count - 2; i >= 0; i--)
            {
                if (dtRangeName_Address.Rows[i][0].ToString() == tagName)
                {
                    ExistingRange = ws.get_Range(dtRangeName_Address.Rows[i][1].ToString());
                    TagAlreadyExists = true;
                    break;
                }
            }
            FilledRange.Interior.ColorIndex = 0;
            FilledRange.Name.Delete();
            if (TagAlreadyExists == true && ExistingRange != null)
            {
                ExistingRange.Interior.Color = Color.YellowGreen;
                ExistingRange.Name = tagName;
            }
            dtRangeName_Address.Rows.RemoveAt(dtRangeName_Address.Rows.Count - 1);
            if (dtRangeName_Address.Rows.Count == 0)
                btnUndo.Enabled = false;
        }

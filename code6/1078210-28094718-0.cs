    private void Application_SheetBeforeRightClick(object Sh, Excel.Range Target, ref bool Cancel)
        {
            Excel.Range ResourceTable;
            Excel.Range IntersectRange;
            foreach (Office.CommandBarControl ctrl in tableCommandBar.Controls)
            {
                if (ctrl.Tag == "Edit" || ctrl.Tag == "Delete") ctrl.Delete();
            }
            editBtn = null;
            if (this.Application.ActiveSheet.Name == "Mysheet" && this.Application.ActiveSheet.ListObjects.Count > 0)  
            {
                ResourceTable = this.Application.ActiveWorkbook.Worksheets["Mysheet"].ListObjects["myTable"].Range;
                IntersectRange = this.Application.Intersect(ResourceTable, Target);
                if (IntersectRange != null & ResourceTable.Rows.Count > 2 && editSourceBtn == null)
                {
                    editBtn = (Office.CommandBarButton)tableCommandBar.Controls.Add(1, missing, missing, missing, missing);
                    editBtn.Style = Office.MsoButtonStyle.msoButtonCaption;
                    editBtn.Tag = "Edit";
                    editBtn.Click += new Office._CommandBarButtonEvents_ClickEventHandler(editSourceBtn_Click);
                }
            }
        }

     GridViewRow row = e.Row;            
            int firstindex = 0;
            int Lastindex = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = e.Row.Cells[0].Text;               
                firstindex = value.IndexOf('5');
                Lastindex = value.LastIndexOf('5');
                string refinedVal = value.Substring(0, firstindex);
                string refinedVal1 = value.Substring(firstindex + 1, Lastindex);
                string refinedVal2 = value.Substring(Lastindex);
                string finalop = refinedVal + "<span style='color:blue'>" + refinedVal1 + @"</span>" + refinedVal2;
                row.Cells[0].Text = string.Empty;
                row.Cells[0].Text = finalop;
            }

    protected void Export2Excel(object sender, EventArgs e)
        {
            gridViewRow.Cells[11].Visible = true;
            gridViewRow.Cells[11].Style["display"] = "inline";
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Mobile.xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            GridView currentGridView = new GridView();
            switch (DeviceType())
            {
                case "cell":
                    currentGridView = gvCellResults;
                    break;
                case "loaner":
                    currentGridView = gvCellResults;
                    break;
                case "wireless":
                    currentGridView = gvCellResults;
                    break;
                case "smartphone":
                    currentGridView = gvSmartPhoneResults;
                    break;
            }
            foreach (GridViewRow gridViewRow in currentGridView.Rows)
            {
                gridViewRow.ForeColor = Color.Black;
                HyperLink phonenumber = new HyperLink();
                HyperLink imei = new HyperLink();
                HyperLink employee = new HyperLink();
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    phonenumber = (HyperLink)gridViewRowTableCell.FindControl("hrefPhoneNumber");
                    imei = (HyperLink)gridViewRow.Cells[1].FindControl("hrefIMEI");
                    employee = (HyperLink)gridViewRow.Cells[6].FindControl("hrefEmpName");
                    gridViewRowTableCell.Style["forecolor"] = "#000000";
                }
               
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    for (int columnIndex = 0; columnIndex < gridViewRow.Cells.Count; columnIndex++)
                    {
                        gridViewRow.Cells[columnIndex].Attributes.Add("class", "text");
                        gridViewRow.Cells[columnIndex].Text = gridViewRow.Cells[columnIndex].Text.StripTags();
                    }
                    if (phonenumber != null)
                        gridViewRow.Cells[0].Text = phonenumber.Text;
                    if (imei != null)
                        gridViewRow.Cells[1].Text = imei.Text;
                    if (employee != null)
                        gridViewRow.Cells[6].Text = employee.Text;
                }
            }
            currentGridView.RenderControl(htmlTextWriter);
            string style = @"<style> .text { mso-number-format:\@; } </style> ";
            Response.Write(style);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

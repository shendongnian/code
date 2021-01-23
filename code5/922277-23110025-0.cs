    protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in this.Rows)
                if (row.RowType == DataControlRowType.DataRow)
                    foreach (DataControlFieldCell cell in row.Cells)
                        if ((cell.ContainingField).HeaderText != "Detalhes")
                            cell.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this, string.Format("Select${0}", row.RowIndex), true);
            base.Render(writer);
        }

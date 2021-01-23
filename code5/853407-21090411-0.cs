             if (e.RowType == GridViewRowType.Data)
             {              
                ASPxGridView dgrdResults = sender as ASPxGridView;
                ASPxHyperLink destinationLink = dgrdResults.FindRowCellTemplateControl(e.VisibleIndex, null, "DestinationLink") as ASPxHyperLink;
                ASPxHyperLink statusLink = dgrdResults.FindRowCellTemplateControl(e.VisibleIndex, null, "stt_display_order") as ASPxHyperLink;
                if (e.GetValue("bnd_name") != null)
                {
                    int DrId = Convert.ToInt32((e.GetValue("dr_id")));
                    destinationLink.NavigateUrl = "./included_codes.aspx?mode=Edit&dr_id=" + DrId;
                }
                else
                {
                    destinationLink.Enabled = false;
                    destinationLink.ForeColor = Color.Black;
                }
            }

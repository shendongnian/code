                        string gridText = gvCountry.SelectRow.Cells[1].text;
    
                        if (ddlCountry.Items.FindByText(gridText) != null)
                        {
                            ddlCountry.ClearSelection();
                            ddlCountry.Items.FindByText(gridText).Selected = true;
                        }

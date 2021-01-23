    #region by zia for if item not exist in dropdownlist
                        string qlf = dsEmp.Tables["tblEmp"].Rows[0]["Group"].ToString();
                        ListItem selLqli = ddlGroup.Items.FindByText(qlf.Trim());
                        if (selLqli != null)
                        {
                            ddlGroup.ClearSelection();
                        }
                        else
                        {
                            ddlGroup.SelectedIndex = 0;
    
                        }
                        #endregion

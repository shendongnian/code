      private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox TextBoxName = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                        TextBox TextBoxAge = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtAge");
                        TextBox TextBoxAddress =
                          (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtAddress");
                        RadioButtonList RBLGender =
                          (RadioButtonList)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("RBLGender");
                        DropDownList DrpQualification =
                          (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("drpQualification");
                        
                        //Added these lines
                        Classes.CRUD obj = new Classes.CRUD();
                        DrpQualification.DataSource = obj.ShowAllAccounts();
                        DrpQualification.DataBind();
                        //****************
                        TextBoxName.Text = dt.Rows[i]["Col1"].ToString();
                        TextBoxAge.Text = dt.Rows[i]["Col2"].ToString();
                        TextBoxAddress.Text = dt.Rows[i]["Col3"].ToString();
                        RBLGender.SelectedValue = dt.Rows[i]["Col4"].ToString();
                        DrpQualification.SelectedValue = dt.Rows[i]["Col5"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

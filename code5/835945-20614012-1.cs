            protected void GridViewStudents_RowCommand(object sender, GridViewCommandEventArgs e)
                    {
                        if (e.CommandName == "Remove")
                        {
                           // I stored the ID of the selected Student I want to delete in a viewstate.
                                        ViewState.Add("DeletedStudDetailID",Convert.ToInt32(e.CommandArgument));
     ModalpopupExtender.Show();
                        }
                            
                     }
    
    // Here in the accept delete button I used that code ..
            protected void Buttonaccept_Click(object sender, EventArgs e)
            {
                try
                {
                    if (ViewState["DeletedStudDetailID"] != null)
                    {
                        StudentDetail StudDet = Data.StudentDetails.Single(SD => SD.Fk_Stud_ID == Convert.ToInt32(ViewState["DeletedStudDetailID"]));
                        Data.StudentDetails.DeleteOnSubmit(StudDet);
                        Student Stud = Data.Students.Single(S => S.Stud_ID == Convert.ToInt32(ViewState["DeletedStudDetailID"]));
                        Data.Students.DeleteOnSubmit(Stud);
                        Data.SubmitChanges();
                    }
                    this.ResultMessage = "Delete Done Sucessfully !!";
                }
                catch
                {
                    this.ErrorMessage = "Delete operation disordered !!";
                }
                finally
                {
                    ModalPopExtender.Hide();
                }
    
            }

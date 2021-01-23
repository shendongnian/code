    if (row.RowType == DataControlRowType.DataRow)
                        {
                            Label UserId = row.FindControl("lblUsrID") as Label;
                            TextBox Start_Date = row.FindControl("txtStartDate") as TextBox;
    
                            TextBox End_Date = row.FindControl("txtEndDate") as TextBox;
                            CheckBox Reg_Appr = ((CheckBox)row.FindControl("txtchkUsrApp")) as CheckBox;
    
                            string myUserID = UserId.Text;
    
                                 myCmd.Connection = myCon;
                                 myCmd.CommandType = CommandType.Text;
                                 myCon.Open();
                                 myCmd.CommandText = "update myTable set Start_Date = @Start_Date, End_Date = @End_Date, Reg_Appr = @Reg_Appr where UserId = @UserId  ";
                                 myCmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId.Text;
                                 myCmd.Parameters.Add("@Start_Date", SqlDbType.VarChar).Value = Start_Date.Text;
                                 myCmd.Parameters.Add("@End_Date", SqlDbType.VarChar).Value = End_Date.Text;
    
                                 myCmd.Parameters.Add("@Reg_Appr", SqlDbType.Bit).Value = Reg_Appr.Checked;                                
                                 SendActivationEmail(myUserID);
                                 // added this line
                                 myCon.Close();
                        }

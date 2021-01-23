    void OnButtonCliked(object sender, eventargs e)
    {
       string connStr = 
               ConfigurationManager.ConnectionStrings["email"].ConnectionString;
               SqlConnection mySQLconnection = new SqlConnection(connStr);
               string empId = string.Empty;
               DataTable dt = new DataTable();
               try
               {
               mySQLconnection.Open();
               for (int i = 0; i < Repeateremail.Items.Count; i++)
               {
                CheckBox checkboc = 
              ((CheckBox)Repeateremail.Items[i].FindControl("chkSelect"));
                if (checkboc != null)
                {
 
                    if (checkboc.Checked == true)
                    {
                        string emailId = 
                   ((Label)Repeateremail.Items[i].FindControl("lbl_email")).Text;
 
                        //you should do something here..like
                        string query = "update loginTable set isEmailSent = 'true' where email = emailID";
                        //execute the query here...
                        SendEmailUsingGmail(emailId);
                        dt.Clear();
                        dt.Dispose();
                      //then use Repeater bind to bind the data...and in repeater bind function you can get the value of checkbox and then set the Repeaeteremail.Items checkboxes to the values updated above
                    }
                    else if (checkboc.Checked == false )
                    {
                         //do samething as above just update the string with isEmailSent = 'false' 
                    }
                }
            }    
    }

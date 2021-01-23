    protected void emlSend_Click(object sender, EventArgs e)
    {
        byte[] bytes;
        string fileName;
        MailMessage email = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("attgmail");
        email.From = new MailAddress(txtFrom.Text);
        email.To.Add(txtTo.Text);
        email.Subject = txtSub.Text;
        email.Body = txtMsg.Text;
        //Loop through lstFiles to get all values
        foreach (ListItem item in lstFiles.Items)
        {
            if (item.Selected)
            {
                //Save value to string
                string lstItem = item.Text;
                string lstValue = item.Value;
                //Connect to Server
                string constr = ConfigurationManager.ConnectionStrings["fishbowlConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        //Use value in Select statement
                        cmd.CommandText = "SELECT FileName, FileType, Data from CVData where cvID = '" + lstValue + "'";
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            //Get CV Data
                            sdr.Read();
                            bytes = (byte[])sdr["Data"];
                            fileName = sdr["FileName"].ToString();
                            //This works if files are stored in folder instead of the below code
                            //Attachment resume = new Attachment(Server.MapPath(VirtualPathUtility.ToAbsolute("~/images/cv/" + fileName)));
                            //Attach Data as Email Attachment
                            MemoryStream pdf = new MemoryStream(bytes);
                            Attachment data = new Attachment(pdf, fileName);
                            email.Attachments.Add(data);
                        }
                        con.Close();
                    }
                }
            }
        }
        //send the message
        SmtpClient smtp = new SmtpClient();
        smtp.Send(email);
        lblEmail.Text = "Email was sent Successfully";
    }

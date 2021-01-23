    protected void Button2_Click(object sender, EventArgs e)
    {
        
        //string vv;
        //vv = (string)Session["FID"];
        DateTime sdt = DateTime.Today;
        
        SqlCommand cmd4 = new SqlCommand();
        int flag=0;
       
       
       String test = DateTime.Now.ToString("dd.MM.yyy");
       for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
       {
           string toemail = GridView1.Rows[i].Cells[2].Text;
           string FID1 = GridView1.Rows[i].Cells[0].Text;
           GridViewRow row = GridView1.Rows[i];
           CheckBox Ckbox = (CheckBox)row.FindControl("CheckBoxMark1");
           if (Ckbox.Checked == true)
           {
               sendMail(toemail);
               flag = 1;
               //ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Email send Succesfully')</script>");
           }
           if (flag == 1)
           {
               //ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Email sent  on " + test + "')</script>");
               cn.Open();
               //cmd4.CommandText = "Insert into TrackingFaculty_det  (EmailsentDate)  values (@EmailsentDate) WHERE FID=@FID";
               cmd4.CommandText = "update TrackingFaculty_det SET EmailsentDate=@Email WHERE FID=@FID  ";
               cmd4.CommandType = CommandType.Text;
               cmd4.Connection = cn;
               cmd4.Parameters.Clear();
               cmd4.Parameters.Add("@Email", SqlDbType.DateTime, 8);
               cmd4.Parameters["@Email"].Value = sdt;
               cmd4.Parameters.Add("@FID", SqlDbType.VarChar, 10);
               cmd4.Parameters["@FID"].Value = FID1;
               cmd4.ExecuteNonQuery();
               cn.Close();
               log.Debug("Info : Insert the Email Sent Date of the faculty");
           }
           
           
           
       }
       log.Debug("Info : Function used to send mail");
    }
    public void sendMail(String toemail)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toemail);
            mail.From = new MailAddress("manipal.mcis1@gmail.com");
            mail.Subject = "Remember Mail";
            // string Body = "Please update profile";
            //mail.Body = Body;
            mail.Body = "  Dear Sir/Madam \n\n\n Please update your profile. . \n\n\n Thanks & Regards \n\n\n MCIS,Manipal.";
            //mail.Body = "<html><body> <h2" + "align=center>Dear Sir/Madam" + "</h2> Please update ur profile</body></html>";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("manipal.mcis1@gmail.com", "manipal15");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        catch (SmtpException ex)
        {
            string msg = "Mail cannot be sent because of the server problem:";
            msg += ex.Message;
            log.Debug("Error: Inside catch block of Mail sending");
            log.Error("Error msg:" + ex);
            log.Error("Stack trace:" + ex.StackTrace);
            Response.Write(msg);
            //throw new Exception(msg);
            
        }

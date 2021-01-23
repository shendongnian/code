    protected void btnSubmit_Click(object sender, EventArgs e)
        {
    
            DateTime startDate = Convert.ToDateTime(txtStartDate.Text + " " + ddlTime.SelectedValue);
            DateTime endDate = Convert.ToDateTime(txtEndDate.Text + " " + ddlTime2.SelectedValue);
            if (startDate >= DateTime.Now)
            {
                if (endDate <= startDate)
                {
                    usrComment.Visible = true;
                    usrComment.Text = "Please enter a Return date later than " + startDate;
                }
                else
                {
                    if (Page.IsValid)
                    {
                        string EmailServer = WebConfigurationManager.AppSettings["Email.Server"];
                        int ServerPort = Int32.Parse(WebConfigurationManager.AppSettings["Email.ServerPort"]);
                        string EmailServerUser = (WebConfigurationManager.AppSettings["Email.UserName"]);
                        string EmailServerPass = (WebConfigurationManager.AppSettings["Email.Password"]);
    
                        string EmailFrom = (WebConfigurationManager.AppSettings["Email.From"]);
                        string EmailTo = (WebConfigurationManager.AppSettings["Email.To"]);
                        string EmailToUser = txtEmail.Text;
                        string EmailSubject = "Quote Form submitted";
    
                        ****.****.*****.Email m = new ****.****.Helpers.Email(EmailServer, ServerPort, EmailServerUser, EmailServerPass);
    
                        StringBuilder html = new StringBuilder();
                        html.AppendLine("<ul>");
                        html.AppendLine("<li>" + lblName.Text + ": " + txtName.Text + "</li>");
                        html.AppendLine("<li>" + lblEmail.Text + ": " + txtEmail.Text + "</li>");
                        html.AppendLine("<li>" + lblPhone.Text + ": " + txtPhone.Text + "</li>");
                        html.AppendLine("<li>" + lblVehicleType.Text + ": " + ddlVehicleType.SelectedValue + "</li>");
                        html.AppendLine("<li>" + lblPickupDate.Text + ": " + txtStartDate.Text + "</li>");
                        html.AppendLine("<li>" + ddlTime.SelectedValue + "</li>");
                        html.AppendLine("<li>" + lblReturnDate.Text + ": " + txtEndDate.Text + "</li>");
                        html.AppendLine("<li>" + ddlTime2.SelectedValue + "</li>");
                        html.AppendLine("</ul>");
    
                        m.SendHTMLEmail(EmailFrom, EmailTo, EmailSubject, html.ToString());
    
                        //Response.Redirect("/contact-us/quote-form-submitted.aspx");
                    }
                    usrComment.Text = "SUBMIT IT NOW!!!!!";
                }
            }
            else
            {
                usrComment.Visible = true;
                usrComment.Text = "Please enter a Start date later than " + DateTime.Now;
            }
        }

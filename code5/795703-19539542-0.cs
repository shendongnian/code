     DBconnect dbcon = new DBconnect();
            if (dbcon.Checkmail(tbx_Remail.Text) == true)
            {
                lbl_Remail.Text = "This email is already used";
            }
            else
                lbl_Remail.Text = "";
            if (tbx_Rpassword.Text == tbx_Rrenter.Text && lbl_Remail.Text=="")
            {
                Mail mail = new Mail();
                Hashing hash = new Hashing();
                string confirmationcode = tbx_Rpostal.Text + tbx_Remail.Text;
                Account acc = new Account("user", tbx_Rname.Text, tbx_Rcity.Text, tbx_Rstate.Text, tbx_Remail.Text, tbx_Rpostal.Text, tbx_Radress.Text, tbx_Rtelephone.Text, hash.hashpass(tbx_Rpassword.Text, "asIoqc"));
                dbcon.CreateAccount(acc);
                if (!mail.ActivationEmail(tbx_Remail.Text, "Dear " + tbx_Rname.Text + ", <br /><br />By pressing the link underneed you confirm you're account. <br /><a href=http://cngraphix.com/validate.aspx?Confirm=" + confirmationcode + ">Click here to confirm</a> <br /><br />Best regards,<br />The Management Team.", tbx_Remail.Text))
                {
                    Response.Redirect("index.aspx?nullexeption=1");
                }
                else
                {
                    dbcon.SetActivation(confirmationcode, tbx_Remail.Text);
                }
                btn_Rreset_Click(this, new EventArgs());
            }
        

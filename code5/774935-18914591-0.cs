      protected void addnewtext_Click(object sender, EventArgs e)
        {     
            
                AddVisaControl ac = (AddVisaControl)Page.LoadControl("AddVisaControl.ascx");
                PlaceHolder1.Controls.Add(ac);
                PlaceHolder1.Controls.Add(new LiteralControl("<BR>"));
            
        }

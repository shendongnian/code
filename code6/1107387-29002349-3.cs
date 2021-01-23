        protected void btnShow_Click(object sender, EventArgs e)
        {
            MasterPage ctl00 = FindControl("ctl00") as MasterPage;
            // Get a reference to the ContentPlaceHolder
            ContentPlaceHolder MainContent = ctl00.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            // Reference the Label and TextBox controls
            TextBox myControl1 = MainContent.FindControl("txtTest") as TextBox; //your textbox Id here *ex:* txtPId
            if (myControl1 != null)
            {
                //Control myControl2 = myControl1.Parent;
                //Response.Write("Parent of the text box is : " + myControl2.ID);
                Response.Write("Text is:  " + myControl1.Text);
            }
            else
            {
                Response.Write("Control not found");
            }
        }

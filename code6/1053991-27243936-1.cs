        protected void Remove(object sender, EventArgs e)
        {
            foreach (Control control in PlaceHolder1.Controls)
            {
                //Here you need to take ID from ViewState["controlIdList"]
                if (control.ID == "TakeIDFromControlListsID")
                {
                    Controls.Remove(control);
                }
            }
         }

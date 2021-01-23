            foreach (System.Web.UI.Control control in this.Controls)
            {
                if (control is System.Web.UI.WebControls.TextBox)
                {
                    if ((System.Web.UI.WebControls.TextBox)control).Text != "")
                    {
                        // Do something
                    }
                }
            }

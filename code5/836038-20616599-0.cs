            foreach ( System.Windows.Forms.Control control in this.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    if (((System.Windows.Forms.TextBox)control).Text != "")
                    {
                        // Do something
                    }
                }
            }

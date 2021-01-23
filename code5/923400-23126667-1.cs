            bool canEdit = false;
    
            private void panel1_VisibleChanged(object sender, EventArgs e)
            {
                if (!canEdit)
                {
                    button1.Enabled = false;
                    //and other components that u want
                }
                else
                {
                    button1.Enabled = true;
                    //and other components that u want
                }
            }

    protected void PageLoad(object sender, EventArgs e)
    {
            //some checking hee to determine whether user is admin or not.
            if (isAdmin)
            {
                var btnAdmin = new Button();
                btnAdmin.Click += btn_Click;
                btnAdmin.Text = "Admin";
                btnAdmin.ID = "admin_B";
                
                otherControl.Controls.Add(btnAdmin); // you need to create otherControl on page
            }
    }

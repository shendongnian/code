    public void OpenMyForm(string sectionName, string[] keys, Form myform)
            {
                //make sure there are no other forms of the ame type open
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == myform.GetType())
                    {
                        form.Activate();
                        return;
                    }
                }
    
                var newSignIn = new Verify();
                newSignIn.MdiParent = this;
                newSignIn.FormClosed += delegate
                {
    
                    if (UserInfo.Autherized == true)
                    {
                        UserInfo.Autherized = false;
                        var role = new Roles();
    
                        if (role.hasAccess(sectionName, keys))
                        {
                            var newMDIChild = myform;
    
                            // Set the Parent Form of the Child window.
                            newMDIChild.MdiParent = this;
    
                            newMDIChild.Dock = DockStyle.Fill;
                            // Display the new form.
                            newMDIChild.Show();
                            newSignIn.Close();
                        }
                        else
                        {
                            Common.Alert("You do not have a permissions to perform this action!");
                        }
                    }
                };
    
                newSignIn.Show();
            }

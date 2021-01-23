        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList UserList = new ArrayList();
            var SkypeClient = new SKYPE4COMLib.Skype();
            foreach(SKYPE4COMLib.Group Group in SkypeClient.CustomGroups)
            {
                    if (Group.DisplayName == "<specify the usergroup name here>")
                    {
            	        foreach (SKYPE4COMLib.User User in Group.Users)
                        {
                            //Adds the usernames from the specified group in the list.
                            UserList.Add(User.Handle);
            	        }
                    }
            }
            //Writing the list in a label
            string s = "";
            foreach(string str in UserList)
            {
                s = s + str + Environment.NewLine;
            }
            label1.Text = s;
        }

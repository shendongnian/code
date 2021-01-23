    public List<string> GetUserRoles( string currentUser)
            {
            N_Roles_Users allroles = new N_Roles_Users();
            List<string> roleslist = new List<string>();
            List<char> temp = new List<char>();
             **if(allroles.user_name.ToList()!=null &&  allroles.user_name.ToList().Count!=0)
              {
             temp = allroles.user_name.ToList();
             }**
            List<char> tempa = new List<char>();
            tempa = allroles.role_name.ToList();
    
            for (int i = 0; i < temp.Count; i++) // Loop through List with for
                {
                if (currentUser == temp[i].ToString())
                    {
                    roleslist.Add(tempa[i].ToString());
                    MessageBox.Show(tempa[i].ToString());
                    }
                }
            return roleslist;
            }

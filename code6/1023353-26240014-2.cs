        public partial class teststack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            List<RolePerson> lrp = new List<RolePerson>();
            // Get the string from the hidden field
            string strData = this.TestString.Value;
            // split the string into an array each value in the array haveing name;role
            string[] strRecords = strData.Split(new Char[] {','});
            // process the array and add to the list
            foreach (string s in strRecords)
            {
                string[] strRecord = s.Split(new Char[] { ';' });
                lrp.Add(new RolePerson{
                    Person = strRecord[0],
                    Role = strRecord[1]
                });
            }
            // Find the person for the specified role
            FindPerson(lrp, this.RoleToFind.Text);
        }
        //Find the people for the specified role and add to the results textbox
        private void FindPerson(List<RolePerson> lrp, string strRole)
        {
            this.Result.Text = null;
            string strResults = string.Empty;
            foreach (RolePerson rp in lrp)
            {
                if (rp.Role == strRole)
                    strResults = strResults + rp.Person + "\r\n";
            }
            this.Result.Text = strResults;
        }
    }

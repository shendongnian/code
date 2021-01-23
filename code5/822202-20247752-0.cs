    public partial class Application
    {
        private string estateName(sspData myDataSource)
        {
            string esName = "";
            string uName = this.User.Identity.Name;
            try
            {
                 var qryUser = myDataSource.aspnet_Users.Where(a => (a.UserName == uName)).SingleOrDefault();
                esName = qryUser.PayGroup;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException.ToString());
            }
            return esName;
        }
    }

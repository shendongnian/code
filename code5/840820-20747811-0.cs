    public class MyAppPrincipal :IPrincipal, IMyAppPrincipal
          {
                private IIdentity _identity;
                private string _department;
                public MyAppPrincipal( IIdentity identity, department)
                {
                      _identity = identity;
                      _department = department;
                }
                                
                public bool IsPageEnabled(string pageName)
                {
                    //DB is your access to your database, I know that you´re using plain ADO.NET here so put query here or cache the elements in your app_start and read them from it....
                    //let´s say you have a method that you pass the pagename and the department
                     return DB.IsPageEnabled( pageName, this._department);
                }
            }

     public partial class _Default : System.Web.UI.Page
     {
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!Page.IsPostBack)
             GetADUsers();
      }
      public void GetADUsers()
      {
          DirectoryEntry myLdap = new DirectoryEntry("LDAP://OU=Nix,DC=systems,DC=com");
          DirectorySearcher search = new DirectorySearcher(myLdap);
          search.CacheResults = true;
          search.SearchScope = SearchScope.Subtree;
          search.Filter = "(objectlass=person)";
          SearchResultCollection allResults = search.FindAll();
          search.PropertiesToLoad.Add("samaccountname");
          Grid1.DataSource = allResults;
          Grid1.DataBind();
     }

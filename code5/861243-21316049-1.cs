    public class BaseWebForm : System.Web.UI.Page
    {
    private string _activePageTitle = string.Empty;
	protected override void OnPreLoad(EventArgs e)
	{
		string defaultPageTitle = ConfigurationManager.AppSetting["defaultWebPageTitle"];
		//Load the theme and masterpage.
		base.OnPreInit(e);
        
        Page.Title = (!String.IsNullOrEmpty(_activePageTitle) ? characterReplace(_activePageTitle)    + " | " + defaultPageTitle : defaultPageTitle);
        }
    	public string ActivePageTitle
	    {
		    get
		    { return _activePageTitle; }
		    set
		    { _activePageTitle = value; }
	    }
    }

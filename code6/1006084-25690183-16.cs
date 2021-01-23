    public /* abstract */ class claPageBaseForm : System.Web.UI.Page
    {
    
    	protected claPageBaseForm()
    	{
    		System.Threading.Thread.CurrentThread.CurrentCulture = 
    new System.Globalization.CultureInfo(System.Globalization.CultureInfo.
    CurrentCulture.Name, false);
    		System.Threading.Thread.CurrentThread.CurrentUICulture = 
    new System.Globalization.CultureInfo(System.Globalization.CultureInfo.
    CurrentCulture.Name, false);
    	}
    
    }

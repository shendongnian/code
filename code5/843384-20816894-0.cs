	public class MyPage : Page
	{
		public abstract string PageTitle {get;}
	    protected void Page_Init(object sender, EventArgs e){ 
	          //do some basic opeation
	        this.Title = PageTitle;
	    }
	}

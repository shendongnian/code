	public abstract class MyPage : Page
	{
		public abstract string PageTitle {get;}
	    protected override void OnInit(EventArgs e){ 
	          //do some basic opeation
	        this.Title = PageTitle;
            base.OnInit(e);
	    }
	}

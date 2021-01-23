    public partial class MyPage : ContentPage
    {
    	public MyPage ()
    	{
    		this.TextProp = "Some Text";
    		InitializeComponent ();
    	}
    
    	public string TextProp
    	{
    		get;
    		set;
    	}
    }

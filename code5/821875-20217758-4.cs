    public partial class Dictionary1 : ResourceDictionary
    {
    	public Dictionary1()
    	{
    		InitializeComponent();
    	}
    
    	void TextBox_GotFocus(object sender, RoutedEventArgs e)
    	{
    		MessageBox.Show(sender.ToString());
    	}
    }

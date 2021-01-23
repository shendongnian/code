    public partial class MainPage : PhoneApplicationPage
        {
            // Constructor
            public MainPage()
            {
                int m = 3;
                InitializeComponent();
                for (int r = 0; r < m; r++)
                {
                    TextBlock myTextBlock = new TextBlock()
                    {
                        Text = "Text Block",
                        Width = 350,
                        Height = 40,
                        FontSize = 20,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
    
                    //If tap event required for all text box
                    myTextBlock.Tap += myTextBlock1_Tap;
                    
                    //According to your code here you have triggered tap event 
                    //only for the first textblock
                    if (r == 0)
                    {
                        myTextBlock.Tap += new
                           EventHandler<GestureEventArgs>(myTextBlock1_Tap);
                    }
                    // Adding to the parent Stackpanel
    
                    stack1.Children.Add(myTextBlock);
                    myTextBlock.Text = "My textblock "+r;
                }
               
            }
            public void myTextBlock1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
            {
                StackPanel mystack = new StackPanel() { Height = 100, Width = 200 };
                TextBlock myTextBlock1 = new TextBlock()
                {
                    Text = "Text Block",
                    Width = 350,
                    Height = 40,
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                mystack.Children.Add(myTextBlock1);
                // Adding to the parent Stackpanel
                stack1.Children.Add(mystack);
            }
        }

        public partial class ServerRNG : UserControl
        {
             private sp;
    
             public ServerRNG(SplitPage1 splitPage) : this()
             {
                  sp = splitPage; // Save a reference to the currently displayed `SplitPage1` page
             }
    
             public ServerRNG()
             {
                  InitializeComponent();
             }
    
             private void Button_Click_1(object sender, RoutedEventArgs e)
             {
                    Random r = new Random(2);
                    int number = r.Next(0, 100);
                    r2Out.Text = number.ToString();
                    sp.Setr1SSLBox(number); // Set the correct instance's text
             }
        }

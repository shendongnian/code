    public sealed partial class Page1
        {
          public Page1() { InitializeComponent(); }
          .
          private void GoToPage2(object sender, RoutedEventArgs e)
          {
            Frame.Navigate(typeof(Page2), new string[] { "hello", "world", "sample" });
          }
        }

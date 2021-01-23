    public class MyPage : PhoneApplicationPage
    {
        public MyPage()
        {
            this.BuildPage();
        }
        private void BuildPage()
        {
            var panel = new StackPanel();
            panel.Children.Add(new TextBlock { Text = "Hello" });
            panel.Children.Add(new TextBlock { Text = "World" });
            this.Content = panel;
        }
    }

    public class Main : Window
    {
        private Label label;
        public void Foo()
        {
            Popup popup = new Popup();
            popup.Check += value => label.Content = value;
            popup.ShowDialog();
        }
    }

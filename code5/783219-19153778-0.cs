    public class MyUserControl {
        private Button myButton;
        public event EventHandler MyControlButtonClicked;
        public MyUserControl() {
             ...
             myButton.Click += OnMyButtonClicked;
        }
        private void OnMyButtonClicked(object sender, EventArgs arguments) {
            if (MyControlButtonClicked != null) {
               MyControlButtonClicked(this, arguments);
            }
        }
    }

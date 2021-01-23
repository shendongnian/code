    public class Presenter
    {
        private IView view;
        public Presenter(IView view)
        {
            this.view = view;
        }
        private void _ValidateInput()
        {
            string text = this.view.Input;
            If (text is InValid)
            MessageBox.Show ("The value in the Text box is invalid");
        }
    }

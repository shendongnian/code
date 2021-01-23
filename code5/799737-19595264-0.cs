    public class ChildForm2 : Form
    {
        private TextBox texbox1;
        public event EventHandler TextboxEdited;
        private void OnTextboxEdited(object sender, EventArgs args)
        {
            if (TextboxEdited != null)
                TextboxEdited(sender, args);
        }
        public ChildForm2()
        {
            texbox1.TextChanged += OnTextboxEdited;
        }
    }

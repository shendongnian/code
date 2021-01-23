    partial class AddReview : Form
    {
        public event EventHandler SpecialButtonClicked;
        public AddReview()
        {
            InitializeComponent();
            // Normally you'd hook this up in the Designer, but for the sake of
            // illustration, I show the subscription here
            button1.Click += button1_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler handler = SpecialButtonClicked;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
    partial class MainScreen : Form
    {
        private void SomeMethod()
        {
            AddReview addReview = new AddReview();
            addReview.SpecialButtonClicked += (sender, e) => GetTrackLayout();
            addReview.Show();
        }
    }

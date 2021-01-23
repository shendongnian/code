    class BookForm : Form
    {
        protected virtual void SubscribeButton()
        {
            this.btnSubmit.Click += new System.EventHandler(this.btnBack_Click);
        }
        public BookForm()
        {
            InitializeComponent();
            SubscribeButton();
        }
    }
    class PaidBookForm : Form
    {
        protected override void SubscribeButton()
        {
            this.btnSubmit.Click += new System.EventHandler(this.btnBuy_Click);
        }
    }

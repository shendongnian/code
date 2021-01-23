        public BookDetailsForm()
        {
            InitializeComponent();
        }
        public BookDetailsForm(Book book)
            : base()
        {           
            // add the init here
            _book = book;
            InitializeComponent();
            // map the book to the view
            // example:
            lblName.Text = _book.Title;
        }
        private void BookDetailsForm_Load(object sender, EventArgs e)
        {
            label1.Text = _book.Title;
        }

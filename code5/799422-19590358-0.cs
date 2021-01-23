    public class BookPanel : Panel
    {
        public string BookName
        {
            get { return text.Text; }
            set { text.Text = value; }
        }
        public Image BookCover
        {
            get { return pic.Image; }
            set { pic.Image = value; }
        }
        public event EventHandler BuyBook;
        public string BuyButtonText
        {
            get { return button.Text; }
            set { button.Text = value; }
        }        
        //inner child controls
        PictureBox pic = new PictureBox();
        TextBox text = new TextBox();
        Button button = new Button();
        public BookPanel()
        {
            pic.Parent = text.Parent = button.Parent = this;
            pic.Top = 5;
            text.Left = pic.Left = 5;
            button.Text = "Buy";
            button.Width = 50;
            button.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            text.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            pic.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            button.Click += (s, e) =>
            {
                EventHandler handler = BuyBook;
                if (handler != null) handler(this, EventArgs.Empty);
            };
        }
        bool init;
        protected override void OnSizeChanged(EventArgs e)
        {            
            base.OnSizeChanged(e);
            if (!init)
            {
                text.Width = Width - button.Width - 12;
                button.Left = text.Right + 5;
                pic.Height = Height - 35;
                pic.Width = Width - 10;
                text.Top = pic.Bottom + 5;
                button.Top = text.Top - 2;
                init = true;
            }
        }
    }
    //Usage
    bookPanel1.BookCover = yourImage;
    //Try this to see how the Buy button works
    bookPanel1.BuyBook += (s, e) => {
        MessageBox.Show(bookPanel1.BookName);
    };

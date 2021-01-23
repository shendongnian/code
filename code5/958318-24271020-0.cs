    public class AspxPage : Page, IView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter presenter = new Presenter(this);
        }
        public string Input
        {
            get
            {
                return this.textBox.Text;
            }
        }
    }

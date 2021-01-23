    public partial class Default : System.Web.UI.Page
    {
        public List<double> numbers
        {
            get
            {
                var list = ViewState["mylist"];
                if (list == null) ViewState["mylist"] = new List<double>();
                return ViewState["mylist"] as List<double>;
            }             
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            string value;
            double number;
            value = numberTB.Text;
            if (Double.TryParse(value, out number)) numbers.Add(number);
            // you should display some sort of message if the value isnt a number...
        }
    }

    public partial class Default : System.Web.UI.Page
    {
        List<double> numbers = new List<double>();
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

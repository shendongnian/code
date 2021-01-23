    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var results = GetResults();
            if (IsPostBack)
            {
                // retrieve the user input
                var input = reasonNameTextBox.Text;
            }
            else
            {
                // set default value
                reasonNameTextBox.Text = results.Rows[0]["reasonName"].ToString();
            }
        }
    }

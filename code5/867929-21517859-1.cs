    public partial class SomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // The @ character denotes a string literal; just makes it easy to 
                // use multiple lines in this case and keep the inline javascript 
                // code looking nicely formatted within C#
                ClientScript.RegisterStartupScript(this.GetType(), "PopModal", @"
                    $(document).ready(function () {    
                        $('.popup-wrapper').modalPopLite({
                            openButton: '.clicker', 
                            closeButton: '#close-btn', 
                            isModal: true 
                        });    
                    });"
                );
            }
        }
    }

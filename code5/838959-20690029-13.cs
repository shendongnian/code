    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    public partial class _Default : System.Web.UI.Page 
    {
        private string myUserName;
        /*
         * Defining Properties in the source page to be Accessible on the destination page.
         * means Exposing data to other pages using Properties
         * To retrieve data from source page,Destination page must have 
         * <%@ PreviousPageType VirtualPath="~/Default.aspx" %> Directive added below <%@ Page %> Directive
         */
        public string propUserName
        {
            get { return myUserName; }
            set { myUserName = value; }
        }
        private string myPassword;
        public string propPassword
        {
            get { return myPassword; }
            set { myPassword = value; }
        }
	
	
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((txtUsername.Text == "chandan") && (txtPassword.Text == "niit"))
            {
                myUserName = txtUsername.Text;
                myPassword = txtPassword.Text;
            }
           Server.Transfer("Description.aspx");
        }
    }

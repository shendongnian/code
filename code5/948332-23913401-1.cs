    public partial class ConnectedBorrowers_CustomerBasicInput : System.Web.UI.UserControl
    {
        DataTable dtCustomersLegalRelations;   
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {            
                dtCustomersLegalRelations = new DataTable(); 
                Session["table"] = dtCustomersLegalRelations;  
                TrLegalRelations1.Visible = TrLegalRelations2.Visible = TrLegalRelations3.Visible = false;
            } else {
                 dtCustomersLegalRelations = Session["table"] as DataTable;
            }
        }
    
      ...
    }

    protected void Page_Load(object sender, EventArgs e) {
    
        if (!IsPostBack)
        {
            HospNo.Text = DropDownList1.Text;
            
        //other code
        }
     }

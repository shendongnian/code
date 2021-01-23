    Page_Load() {
        GridView1.Visible = IsPostBack;
    }
    
    DataTable result;
    
    Btn_Click() {
        // do some calculations
        result = ...;
    
        // calculations finished... bind the gridview
        GridView1.DataBind();
    }
    
    GetData() {
        return result;
    }

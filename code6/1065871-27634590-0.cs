     //Creating DataTable dt
     DataTable dt = new DataTable(); //Declare dt only once. If this wont work put it in a get set property.
    protected void Page_Load(object sender, EventArgs e)   
     {  
         if ((!IsPostBack) 
         {
            CreateDataTable();
            LoadDataTable();
         }
        gdvView = Nothing; //or Null;
        gdvView.DataSource = dt;
        gdvView.DataBind();
     }
    protected void CreateDataTable()
    {
    //Creating DataTable Columns
        dt.Columns.Add("FName", typeof(string));
        dt.Columns.Add("MName", typeof(string));
        dt.Columns.Add("LName", typeof(string));
        dt.Columns.Add("Phone", typeof(string));
        dt.Columns.Add("EId", typeof(string));
        dt.Columns.Add("State", typeof(string));
        dt.Columns.Add("City", typeof(string));
        dt.Columns.Add("Country", typeof(string));
        dt.Columns.Add("PCode", typeof(string));
        dt.Columns.Add("Gender", typeof(string));
        dt.Columns.Add("AOI", typeof(string));
     }
    protected void LoadDataTable()
    {
         if ((Session["Insert"] == null) //or (Session["Insert"] == nothing)
         {
             Session.Add("Insert", dt);
         }
         else {
            dt = (DataTable)Session["Insert"];
         {
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
    //Do whatever you need to do as is
    dt.Rows.Add(txtFN.Text, txtMN.Text, txtLN.Text, txtPhone.Text, txtEId.Text,     ddlState.Text, ddlCity.Text, txtCountry.Text, txtPCode.Text, rdGender.SelectedValue,    cbAOI.SelectedValue);
    LoadDataTable();
     /* Remove this block if you don't need it here */
        gdvView = Nothing; //or Null;
        gdvView.DataSource = dt;
        gdvView.DataBind();
     /* Remove this block if you don't need it here */
    lblMandatory.Text = "Successfully Inserted into Database";
    System.Threading.Thread.Sleep(1000);
    Response.Redirect("Home.aspx");
    } 

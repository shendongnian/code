     protected void Page_Load(object sender, EventArgs e)
     {
          if (!Page.IsPostBack)
          {
               rptQuestions.DataSource = yourDataSource;
               rptQuestions.DataBind();
          }
     }

    private List<PersonEntered> peopleEntering;
    protected void Page_Load(Object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             peopleEntering = GetPeropleEntering(); // a method that retrieves them from database
        }
    }

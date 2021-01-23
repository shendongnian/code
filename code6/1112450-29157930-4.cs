    [Ninject]
    public IPersonalizationService personalizationService {get; set;}
    
    protected void Page_Load(object sender, EventArgs e)
    {
        MyUserControl1.PersonalizationService = personalizationService;
    }

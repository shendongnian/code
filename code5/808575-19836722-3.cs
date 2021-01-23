    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IConfiguration configuration = ConfigurationFactory.Get();
            new ShowCaseDecoratorA(this.ShowCase).ApplyConfiguration(configuration);
        }
    }

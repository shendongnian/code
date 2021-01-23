    public partial class WebsiteEntities : DbContext
    {
      public WebsiteEntities()
                : base(ConfigurationManager.ConnectionStrings["WebsiteEntities"].ConnectionString ?? "name=WebsiteEntities")
            {
            }
    ...

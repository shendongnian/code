    public class FromUnderscoreMapping : Profile
    {
        protected override void Configure()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<ArticleEntity, Article>();
        }
        public override string ProfileName
        {
            get { return "FromUnderscoreMapping"; }
        }
    }
    public class ToUnderscoreMapping : Profile
    {
        protected override void Configure()
        {
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
            CreateMap<Article, ArticleEntity>();
        }
        public override string ProfileName
        {
            get { return "ToUnderscoreMapping"; }
        }
    }

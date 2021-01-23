    public class SiteSurveyQuestionMap : ClassMap<SiteSurveyQuestion>
    {
        public SiteSurveyQuestionMap()
        {
            Table("SiteSurveyQuestions");
            CompositeId()
                .KeyReference(x => x.Site, "SiteId")
                .KeyReference(x => x.Survey, "SurveyId")
                .KeyReference(x => x.Question, "QuestionId");
            References(x => x.Site, "SiteId"). Not.LazyLoad();  //new
            References(x => x.Survey, "SurveyId").Not.LazyLoad();  //new
            References(x => x.Question, "QuestionId").Not.LazyLoad();  //new
            Map(x => x.IsActive, "ActiveFlag").Not.Nullable();
        }
    }
    //and so on
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Table("Questions");
            Id(x => x.Id, "QuestionId").GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.InternalName);
            Map(x => x.IsActive, "ActiveFlag");
            HasMany(x => x.Choices)
                .KeyColumn("QuestionId")
                .BatchSize(300)  //new
                .AsBag()
                .Cascade
                .AllDeleteOrphan()
                .Inverse()
                .Not.LazyLoad();
        }
    }
    public class ChoiceMap : ClassMap<Choice>
    {
        public ChoiceMap()
        {
            Table("Choices");
            Id(x => x.Id, "ChoiceId").GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.InternalName);
            Map(x => x.IsActive, "ActiveFlag");
            HasMany(x => x.Questions)
                .KeyColumn("ChoiceId")
                .BatchSize(300)  //new
                .AsBag()
                .Cascade
                .AllDeleteOrphan()
                .Inverse();
        }
    }

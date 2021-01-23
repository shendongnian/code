    public class SpecificCategoryFilter : FilterDefinition
    {
        public SpecificCategoryFilter()
        {
            WithName("SpecificCategory").WithCondition("Category = 'A constant expression'");
        }
    }
    public class SpecificLanguageFilter : FilterDefinition
    {
        public SpecificLanguageFilter()
        {
            WithName("SpecificLanguage").WithCondition("Language = 'A constant expression'");
        }
    }

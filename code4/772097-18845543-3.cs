    public class TemplateSqlFileNameProvider : SimpleSqlFileNameProvider
    {
        public TemplateSqlFileNameProvider(string template, string projectName)
            : base(template.Replace("%project_name%", projectName))
        { }
    }
    public class CrByAuthorsFileNameProvider : TemplateSqlFileNameProvider
    {
        public CrByAuthorsFileNameProvider(string projectName)
            : base("Changes_CR_By_Authors_%project_name%.txt", projectName)
        { }
    }
    public class DocumentCrMetricsFileNameProvider : TemplateSqlFileNameProvider
    {
        public DocumentCrMetricsFileNameProvider(string projectName)
            : base("Changes_Document_CR_Output_%project_name%.txt", projectName)
        { }
    }

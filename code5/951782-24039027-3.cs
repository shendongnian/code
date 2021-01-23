    internal class TemplatesCollection
    {
        #region Public Properties
        public List<Template> templates { get; set; }
        #endregion
    }
    internal class TemplateVersion : BaseTemplate
    {
        #region Public Properties
        public string id { get; set; }
        public string updated_at { get; set; }
        #endregion
    }
    internal class BaseTemplate
    {
        #region Public Properties
        public string html_content { get; set; }
        public string name { get; set; }
        public string plain_content { get; set; }
        public string subject { get; set; }
        #endregion
    }
    internal class Template
    {
        #region Public Properties
        public Version[] Versions { get; set; }
        public string default_version_id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        #endregion
    }
    internal class Version
    {
        #region Public Properties
        public string active { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string template_id { get; set; }
        public string updated_at { get; set; }
        #endregion
    }

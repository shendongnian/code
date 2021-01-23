    public class SpecialHtmlTemplateBuilder : HtmlTemplateBuilder
    {
        private bool someCondition;
        public SpecialHtmlTemplateBuilder (bool someCondition)
        {
            this.someCondition = someCondition;
        }
        // ...
    }

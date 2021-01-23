    public class SpecialHtmlTemplateBuilder : HtmlTemplateBuilder
    {
        private bool someCondition;
        public override void LoadTemplates()
        {
            if (someCondition)
            {
                LoadTemplatesSet1();
            }
            else
            {
                LoadTemplatesSet2();
            }
        }
    }

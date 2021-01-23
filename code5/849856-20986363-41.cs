    public class QuestionTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template = null;
            var question = item as Question;
            if (question != null)
            {
                template = question.IsInstruction ? InstructionTemplate : QuestionTemplate;
                if (template == null)
                {
                    template = base.SelectTemplate(item, container);
                }
            }
            else
            {
                template = base.SelectTemplate(item, container);
            }
            return template;
        }
        public DataTemplate QuestionTemplate { get; set; }
        public DataTemplate InstructionTemplate { get; set; }
    }

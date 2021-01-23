    namespace Template.Models.Extensions
    {
        public static class QuestionExtensions
        {
            public static GetQuestionViewModel ToViewModelExtensionMethod(this Question question)
            {
                var result = new GetQuestionViewModel();
                result.field1 = question.field1;
                // ... etc
                return result;
            }
        }   
    }

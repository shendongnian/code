        public string Name { get; set; }
        public string Quiz1 { get; set; }
        public string Quiz2 { get; set; }
        public string Quiz3 { get; set; }
    }
    public class QuizComparer
    {
        public QuizComparer(QuizModel correctOne, IComparer<string> comparer, int quizValue = 1)
        {
            this.CorrectOne = correctOne;
            this.Comparer = comparer;
            this.QuizValue = quizValue;
        }
        public int Compare(QuizModel toCompareOne)
        {
            Type type = toCompareOne.GetType();
            var propertiesInfo = type.GetProperties();
            int result = 0;
            foreach (var propertyInfo in propertiesInfo)
            {
                if (propertyInfo.CanRead)
                {
                    var toCompareOnePropertyValue = type.GetProperty(propertyInfo.Name).GetValue(toCompareOne).ToString();
                    var correctOnePropertyValue = type.GetProperty(propertyInfo.Name).GetValue(this.CorrectOne).ToString();
                    if (Comparer.Compare(toCompareOnePropertyValue, correctOnePropertyValue) == 0)//equals
                    {
                        result += QuizValue;
                    }
                }
            }
            return result;
        }
        public QuizModel CorrectOne { get; set; }
        public IComparer<string> Comparer { get; set; }
        public int QuizValue { get; set; }
    }

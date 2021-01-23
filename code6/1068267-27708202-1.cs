    public class QuizModel
    {
        public string Name { get; set; }
        [QuizValue(value: 1)]
        public string Quiz1 { get; set; }
        [QuizValue(value: 2)]
        public string Quiz2 { get; set; }
        [QuizValue(value: 3)]
        public string Quiz3 { get; set; }
    }
    public class QuizComparer
    {
        public QuizComparer(QuizModel correctOne, IComparer<string> comparer, int quizValue = 1)
        {
            this.CorrectOne = correctOne;
            this.Comparer = comparer;
            this.QuizDefaultValue = quizValue;
        }
        public int Compare(QuizModel toCompareOne)
        {
            Type type = toCompareOne.GetType();
            var propertiesInfo = type.GetProperties();
            int result = 0;
            foreach (var propertyInfo in propertiesInfo)
            {
                if (propertyInfo.CanRead && propertyInfo.Name != "Name")
                {
                    var toCompareOnePropertyValue = type.GetProperty(propertyInfo.Name).GetValue(toCompareOne).ToString();
                    var correctOnePropertyValue = type.GetProperty(propertyInfo.Name).GetValue(this.CorrectOne).ToString();
                    int value = GetQuizValue(propertyInfo);
                    if (Comparer.Compare(toCompareOnePropertyValue, correctOnePropertyValue) == 0)//equals
                    {
                        result += value;
                    }
                }
            }
            return result;
        }
        private int GetQuizValue(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(QuizValue), false);
            int value = this.QuizDefaultValue;
            if (attributes != null && attributes.Count() > 0)
            {
                var quizValueAttribute = attributes[0];
                if (quizValueAttribute is QuizValue)
                {
                    var quizValue = quizValueAttribute as QuizValue;
                    value = quizValue.Value;
                }
            }
            return value;
        }
        public QuizModel CorrectOne { get; set; }
        public IComparer<string> Comparer { get; set; }
        public int QuizDefaultValue { get; set; }
    }
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class QuizValue : System.Attribute
    {
        public QuizValue(int value = 1)
        {
            this.Value = value;
        }
        public int Value
        {
            get;
            set;
        }
    }

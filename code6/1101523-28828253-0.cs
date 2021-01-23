    public class POCO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
    }
    public class POCOValidationResult
    {
        public bool IsValid { get; set; }
        public string Error { get; set; }
    }
    public abstract class Validator<T> where T : class
    {
        public T Entity { get; set; }
        public abstract POCOValidationResult Validate();
        protected POCOValidationResult ValidateStringPropertyToLengthOf(Expression<Func<T, object>> expression, int maxLength)
        {
            var propertyName = getPropertyName(expression);
            var propertyValue = getPropertyValue(expression);
            if (propertyValue.Length > maxLength)
            {
                return new POCOValidationResult()
                {
                    Error = string.Format("{0} value is too long. Must be less or equal to {1}", propertyName, maxLength.ToString())
                };
            }
            return new POCOValidationResult() { IsValid = true };
        }
        internal string getPropertyName(Expression<Func<T, object>> expression)
        {
            var memberExpersion = (MemberExpression)expression.Body;
            return memberExpersion.Member.Name;
        }
        internal string getPropertyValue(Expression<Func<T, object>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            var propertyInfo = memberExpression.Member as PropertyInfo;
            return propertyInfo.GetValue(Entity, null).ToString();
        }
    }
    public class POCOValidator : Validator<POCO>
    {
        public override POCOValidationResult Validate()
        {
            var surnameValidationResult = ValidateStringPropertyToLengthOf(p => p.Surname, 10);
            if (!surnameValidationResult.IsValid)
                return surnameValidationResult;
            var descriptionValidationResult = ValidateStringPropertyToLengthOf(p => p.Description, 100);
            if (!descriptionValidationResult.IsValid)
                return descriptionValidationResult;
            var nameValidationResult = ValidateStringPropertyToLengthOf(p => p.Name, 15);
            if (!nameValidationResult.IsValid)
                return nameValidationResult;
            return new POCOValidationResult() { IsValid = true };
        }
    }
    public class WorkerBee
    {
        public void ImDoingWorkReally()
        {
            var pocoVallidation = new POCOValidator()
            {
                Entity = new POCO()
                {
                    ID = 1,
                    Name = "James",
                    Surname = "Dean",
                    Description = "I'm not 007!"
                }
            };
            var vallidationResult = pocoVallidation.Validate();
            if (!vallidationResult.IsValid)
            {
                return;
            }
            //continue to do work...
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var workerBee = new WorkerBee();
            workerBee.ImDoingWorkReally();
        }
    }

    public class RequiredFieldsError
    {
        private List<string> errors;
        public RequiredFieldsError()
        {
             errors =  new List<string>();
        }
        public int Count
        {
            get{return errors.Count;}
        }
        public void AddField(string errorField)
        {
            errors.Add(errorField);
        }
        public override string ToString()
        {
            if(errors.Count == 0)
               return string.Empty;
            else
            {
               string fields = string.Join(Environment.NewLine, errors);
               fields = "The following fields contains errors:" + Environment.NewLine + fields;
               return fields;
            }
        }
    }

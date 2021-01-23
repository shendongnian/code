    public class SalesOrderMetaData
    {
        private bool isValid;
        public bool IsValid
        {
            get { return isValid; }
        }
    }
    public void Validate()
    {
        // Check business rules here and then set isValid value to true or false
    }

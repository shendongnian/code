    [Serializable]
    public class SearchCriteria 
    {
        public SearchCriteria()
        {
             // Without these initialization the internal variables are all null
             // and so assigning any property of a null object causes the error
             Generic = new _Generic();
             DisplayOnly = new _DisplayOnly()
             Building = new _Building();
        }
        .....
    }

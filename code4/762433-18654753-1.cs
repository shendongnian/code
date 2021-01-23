    public class GetTableQuery
    {
        private readonly string _category;
        private readonly string _language;
    
        public GetTableQuery(string category, string language)
        {
            _category = category;
            _language = language;
        }
    
        public IEnumerable<Table1> Execute(ISession session)
        {
            var returnList = session.QueryOver<Table1>()
                .Inner.JoinQueryOver(t1 => t1.Table2)
                .Where(t2 => t2.Category == _category && t2.Language == _language)
                .List();
    
            return returnList;
        }
    }

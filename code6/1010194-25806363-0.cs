    public class Parameters
    {
        public int Id {get;set;}
        public string FilterParam {get;set;}
        public string NameParam {get;set;}
        public IList<int> CollectionsIds {get;set;}
        [ScriptIgnore]
        public DataTable ParamTable {get;set;}
        
        public List<Dictionary<string, object>> _fakeParamTable
        {
            get
            {
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach ( DataRow dr in ParamTable .Rows )
                {
                    row = new Dictionary<string, object>();
                    foreach ( DataColumn col in dt.Columns )
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return rows;
            }
        }
    }

public class Table : Database
{
    public Filter Filter 
    {
       get;set;
    }
    public Table()
    {
        Filter = new Filter();
    }
    
    public class Filter
    {
        private List<BaseClasses.DataTypes.FilterCondition> conditions = new List<BaseClasses.DataTypes.FilterCondition>();
        public void Add(string column, Int64 value)
        {
            conditions.Add(new BaseClasses.DataTypes.FilterCondition(column, "=", value.ToString()));
	    }
    }
}

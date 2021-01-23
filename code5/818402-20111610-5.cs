        interface IBase
        {
             string SqlColumnName { get; set; }
             SqlDbType SqlColumnType { get; set; }
        }
    
        public abstract class BaseClass : IBase
        {
            public string SqlColumnName { get; set; }
            public SqlDbType SqlColumnType { get; set; }
        }
    
        public class Intclass : BaseClass
        {
            public Intclass()
            {
                base.SqlColumnType = SqlDbType.Int;
            }
        }

    public abstract class BaseClass
    {
        public string SqlColumnName { get; set; }
        public abstract SqlDbType SqlColumnType { get; }
    }
    public class Intclass : BaseClass
    {
        public override SqlDbType SqlColumnType
        {
            get { return SqlDbType.Int;  }
        }
    }

    namespace BusinessLayer
    {
    public class SnapshotBAL
    {
        public Snapshot GetSanpshot(string symbol)
        {
            return (new SnaapshotDAL()).GetSanpshot(symbol);
        }       
    }
    }

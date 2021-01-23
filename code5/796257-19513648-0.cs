    public class IDComparer  : IEqualityComparer<DataRow> 
    {   
        public bool Equals(DataRow x, DataRow y)
        {           
            return (int) x["ID"] == (int) y["ID"] ;
        }
        public int GetHashCode(DataRow obj)
        {                           
            return (int) obj["ID"] ;
        }               
    }           

     public class DataRowComparer : IEqualityComparer<DataRow>  
    	{  
    		public bool Equals(DataRow t1, DataRow t2)  
    		{  
    			return (t1.Field<string>("Email")==t2.Field<string>("Email"));  
    		}  
    		public int GetHashCode(DataRow t)  
    		{  
    			return t.ToString().GetHashCode();  
    		}  
    	}  

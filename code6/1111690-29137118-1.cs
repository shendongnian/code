    public class DataRowPerson{
        public DataRowPerson(DataRow source){
            this.Source = source;
        }
        protected DataRow Source = null;
    
        public string Name(){
            return source["name"].ToString();
        }
        public string LastName(){
            return source["last_name"].ToString();
        }
        public int Age(){
            return Convert.ToInt32(source["age"].ToString()));
        }
    }

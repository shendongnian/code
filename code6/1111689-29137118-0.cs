    public class DataTablePerson{
        public DataTablePerson(DataTable source){
            this.Source = source;
        }
        protected DataTable Source = null;
    
        public string Name(int row = 0){
            return Get("name", row);
        }
        public string LastName(int row = 0){
            return Get("last_name", row);
        }
        public int Age(int row = 0){
            return Convert.ToInt32(Get("age", row));
        }
    
        protected string Get(string name, int row){
            return source.Rows[row][name].ToString();
        }
    }

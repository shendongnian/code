    public class GroupCounter {
        private Dictionary<string, int> serialNumbers;
    
        public GroupCounter() {
            this.serialNumbers = new Dictionary<string, int>();
        }
    
        public Dictionary<string, int> Count(DataTable table) {
            foreach (DataRow row in table.Rows) {
                int counter;
                string serial = row.Field<string>("COLUMN");
                if(!this.serialNumbers.TryGetValue(serial, out counter)){
                    this.serialNumbers.Add(serial, 1);
                }
                counter++;
            }
            return this.serialNumbers;
        }
    }

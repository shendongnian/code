    class Database {
        public static Database Connection = null;
    
        static Database() {
            Database.Connection = new Database();
    
            if (Database.Connection == null) {
                Console.WriteLine("Null");
            }
        }
    
        public Database() {
            Console.WriteLine("I got called");
        }
    }

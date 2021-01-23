    class Program
    {
        static void Main(string[] args)
        {
            SqlCeEngine engine = 
                 new SqlCeEngine("Data Source = C:\\Users\\SomeUser\\Documents\\SomeDB.sdf");
            if (false == engine.Verify())
            {
                Console.WriteLine("Database is corrupted.");
                try
                {
                    engine.Repair(null, RepairOption.DeleteCorruptedRows);
                }
                catch(SqlCeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }

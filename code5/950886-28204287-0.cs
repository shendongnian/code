        static void Main(string[] args)
        {
            string sql = "select * from foo";
            SQLiteCommand command = new SQLiteCommand(sql, null);
            Console.WriteLine(command.CommandText);
            Console.ReadLine();
        }

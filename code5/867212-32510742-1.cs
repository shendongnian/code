    public static void AddStock(SQLiteConnection db, string symbol) {
            var s = db.Insert(new Stock() {
                    Symbol = symbol
            });
            Console.WriteLine("{0} == {1}", s.Symbol, s.Id);
    }

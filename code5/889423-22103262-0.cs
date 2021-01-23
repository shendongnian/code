    using (var connection = _factory.Create("Example.db"))
        {
            connection.CreateTable<Example>();
            return connection.Table<Example>().ToList();
        }//dispose here

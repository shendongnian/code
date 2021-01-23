        public DataTable ToDataTable()
        {
            var table = new TreeDataTable();
            foreach (var f in Files)
                table.AddFile(IdGenerator.Generate(), f, Id);
            foreach (var t in Trees)
                table.AddTree(t);
            return table;
        }

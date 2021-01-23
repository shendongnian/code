    public List<table1HasForeinKey> Details(int Id)
        {
            using (Entities1 context = new Entities1())
            {
                var uploadList = context.table1HasForeinKey.Include("Table2-has-referenced-PrimaryKey").Where(x => x.PrimaryKeyInTable1 == Id).ToList();
                return uploadList;
            }
        }

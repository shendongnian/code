    public class Parent
    {
        public int ParentID { get; set; }
        public List<Child> Children { get; set; }
    }
    public class Child
    {
        public int ChildID { get; set; }
        public List<string> Books { get; set; }
    }
    public class SS
    {
        public int pid { get; set; }
        public int cid { get; set; }
        public string book { get; set; }
    }
    [TestMethod]
    public void AAPlaying()
    {
        var dt = new List<SS>() { };
        dt.Add(new SS() { pid = 1, cid = 4, book = "Grapes of ..."});
        dt.Add(new SS() { pid = 1, cid = 4, book = "Huck......." });
        dt.Add(new SS() { pid = 1, cid = 5, book = "The adven..." });
        dt.Add(new SS() { pid = 2, cid = 4, book = "Grapes of ..." });
        dt.Add(new SS() { pid = 2, cid = 4, book = "Huck......." });
        dt.Add(new SS() { pid = 2, cid = 5, book  = "The adven..." });
        List<Parent> Parents = dt.AsEnumerable().GroupBy(x => x.pid)
            .Select(x => new Parent
            {
                ParentID = x.Key,
                Children = x.GroupBy(y => y.cid).Select(z => new Child
                {
                    ChildID = z.Key,
                    Books = z.Select(b => b.book).ToList()
                }).ToList()
            }).ToList();
    }

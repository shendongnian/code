    public class MyHolder
    {
        public List<MyPart> Parts { get; set; }
    }
    
    public class MyPart
    {
        public int Id { get; set; }
        public bool Taken { get; set; }
        public string Name { get; set; }
    }
    var holder = new MyHolder() { Parts = new List<MyPart>() { new MyPart() { Id = 7, Name = "R", Taken = true }, new MyPart() { Id = 8, Name = "S", Taken = true }, new MyPart() { Id = 9, Name = "T", Taken = true } } };
    List<int> before = holder.Parts.Where(m => m.Taken).Select(f => f.Id).ToList();
    holder.Parts.First(p => p.Id == 7).Taken = false;
    List<int> after = holder.Parts.Where(m => m.Taken).Select(f => f.Id).ToList();

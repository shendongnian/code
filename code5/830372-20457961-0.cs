    public class Pencil
    {
        public string name { get; set; }
        public int price { get; set; }
    }
    public class Pencil1 : Pencil
    {
    }
    List<Pencil> listCopy = list.OfType<Pencil>().ToList(); 

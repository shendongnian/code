    public class Pencil
    {
        public string name { get; set; }
        public int price { get; set; }
    }
    public class Pencil1 : Pencil
    {
    }
    List<Pencil1> list = new List<Pencil1>();
    List<Pencil> listCopy = list.OfType<Pencil>().ToList(); 

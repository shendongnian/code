    public class Unit
    {
    public string Name { get; set; }
    public List<Group> Contains { get; set; }
    public Unit()
    {
    Contains = new List<Group>();
    }
    }

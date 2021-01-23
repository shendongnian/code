    public class Computer
    {
        public int Id { get; set; }
        public string ComputerName { get;set; }
        public virtual User User { get; set; }
    }

    YourEntity.cs //created by EF
    public partial class YourEntity
    {
        public string Name { get; set; }
        ...
    }
    YourEntityExtended.cs // created by you
    public partial class YourEntity
    {
        public int Id { get; set; }       
    }

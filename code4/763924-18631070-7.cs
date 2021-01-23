    public class MyThing:IThing
    {
       [Key]
       [Column("MyThing_ID")
       public int ID{get;set;}
       [Column("MyThing_Data")
       public string Data {Get;set;}
    }

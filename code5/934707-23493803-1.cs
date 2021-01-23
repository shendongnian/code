    [Table("Ticket")]
    class Ticket
    {
       [Key]
       long ID{get;set;}
    }
    [Table("AirTicket")]
    class AirTicket : Ticket
    {
       string SomeSpecialAirProperty{get;set;}
    }

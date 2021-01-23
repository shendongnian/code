    public class EntityBase<T> where T : EntityBase<T>
    {
        //nothing interesting here
    }
    public class Benefit<T> : EntityBase<T> where T : Benefit<T>
    {
        //again, nothing interesting here
    }
    public sealed class SeasonTicketLoan : Benefit<SeasonTicketLoan>
    {
        //nothing interesting here
    }

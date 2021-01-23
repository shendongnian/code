    public class PersonInfo
    {
        string FirstName { get; set; }
        string Surname { get; set; }
        Address Address { get; set; }
    }
    public interface IPersonSearchService
    {
        IEnumerable<PersonInfo> Search(string keyword);
    }
    internal class PersonSearchService : IPersonSearchService
    {
        ....
    }

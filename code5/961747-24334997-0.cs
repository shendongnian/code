    public class Person : IAggregateRoot, IPerson 
    {
       public string Forename { get;set; }
       public string Surname{ get;set; }
       public Title Title { get;set; }
       public DateTime? HireDate { get; set; }
       public void Hire(Title granted, IPersonRepository repository)
       {
           Title = granted;  //Grant the new hire this title that we have at our company
           HireDate = DateTime.Now;
           repository.Save(this);
       }
    }
    public struct Title /* I like to make my value objects structs */
    {
        public Title (Guid id, string value)
        {
            Id = id;
            Value = value;
        }
        public Guid Id { get; private set; }
        public string FullTitle{ get; private set; }  /* This would be the prefix + value + level when loaded from the repository because, in this context, we don't have any need for that level of separation. */
    }

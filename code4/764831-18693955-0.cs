    public class ContainerQuery : IContainerQuery
    {
      public ContainerQuery()
      {
        Clauses = new List<ContainerQueryClause>();
      }
    
      public IEnumerable<ContainerQueryClause> Clauses { get; private set; }
    }

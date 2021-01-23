    // entity with ISet
    public class MyEntity
    {
        ...
        public virtual ISet<Employee> Employees { get; set; }
    }
    // some method adding more items
    var myEntity = ...
    myEntity.Employees.AddAll(collectionOfEmployees)

    [EnableClientAccess]
    public class MyDomainService : DomainService
    {
        [Invoke(HasSideEffects = true)]
        public void UpdateCol3OfAllEntities()
        {
            // Use you data access layer to perform the neccessary
            // query: "UPDATE MyTab SET col3 = 'X'"...
        }
    }

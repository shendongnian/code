    public class PeopleContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        //Create a parent with new children
        public void CreateParent()
        {
            Parents.Add(new Parent
            {
                Children = new List<Child>
                { 
                     new Child(),
                     new Child(),
                     new Child()                
                }
            });
        }
        //Create a child with a new parent
        public void CreateChild()
        {
            Children.Add(new Child
            {
                Parent = new Parent()
            });
        }
    }

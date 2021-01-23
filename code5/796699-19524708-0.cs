    public abstract class Person
    {
        [Key]     
        public int PersonID { get; set; }         
        public string FirstName { get; set; }      
    } 
    public class Employee : Person
    {
        public string Department { get; set; }
    }
    public class FrDetail
    {
        [Key]
        public int FrID { get; set; }      
        public virtual Person RequestorPerson { get; set; }
    }
    public class EFDbContext : DbContext
    {      
           public DbSet<Person> People { get; set; }
           public DbSet<Employee> Employees { get; set; }
           public DbSet<FrDetail> FrDetails { get; set; }    
    } 
    
    public ViewResult List()
    {
        EFDbContext context = new EFDbContext();
        IQueryable<FrDetail> frDetails = context.FrDetails;
        return View(frDetails);
    }
    
    //The view
    
    @model IQueryable<FrDetail>   
    @foreach (var p in Model)
    {
        Html.RenderPartial("FunctionRequestSummary", p);
    }
    
    //Partial View FunctionRequestSummary
    
    @model FrDetail
    @Model.RequestorPerson.FirstName

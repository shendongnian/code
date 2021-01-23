public class Employee {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int ManagerId { get; set; }
    public virtual Employee Manager { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
    public Employee() {
        Employees = new HashSet<Employee>();
    }
}
HasMany(e => e.Employees)
    .WithRequired(e => e.Manager)
    .HasForeignKey(e => e.ManagerId)
    .WillCascadeOnDelete(false);

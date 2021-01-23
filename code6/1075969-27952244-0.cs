    public class EmployeeBuilder
    {
        IFacility facility;
        IDepartment department;        
        public Employee Build()
        {
             return new Employee(IDepartment _department, IFacility _facility);
        }
		
		public EmployeeBuilder WithDepartment(IDepartment _department)
		{
			this.department = department;
			return this;
		}
		public EmployeeBuilder WithFacility(IFacility _facility)
		{
			this.facility = facility;
			return this;
		}
 
        public static implicit operator Employee(EmployeeBuilder instance)
        {
            return instance.Build();
        }
    }
    [TestFixture]
    public class Tests
    {
		[Test]
		public void Test1()
		{
		    IFacility facility= MOCK(IFacility);
			IDepartment department= MOCK(IDepartment);
		    Employee employee = new EmployeeBuilder().WithFacility(facility).WithDepartment(department);
			
		    [exercise]
			
			[asserts]
		}
    }

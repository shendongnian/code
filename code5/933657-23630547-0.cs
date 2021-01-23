    class Employee
    {
    	public string Id { get; set; }
    	public string Name { get; set; }
    	public string Sex { get; set; }
    	public Company Company { get; set; }
    }
    
    class Company
    {
    	public string Id { get; set; }
    	public Department Department { get; set; }
    }
    
    class Department
    {
    	public string Id { get; set; }
    	public Project Project { get; set; }
    }
    
    class Project
    {
    	public string Id { get; set; }
    }
    
    var xml = @"<?xml version='1.0' encoding='utf-8'?>
    <Employees>
    	<Employee>
    		<Id> TG18-2002</Id>
    		<Name> AAPM^Test^Patterns</Name>
    		<Sex> O </Sex>
    		<Company>
    			<Id> 2.16</Id>
    			<Department>
    				<Id> 2.16.124</Id>
    				<Project>
    					<Id> 2.16.124.113543</Id>
    				</Project>
    			</Department>
    		</Company>
    	</Employee>
    	<Employee>
    		<Id> TG18-2003</Id>
    		<Name> AAPM^Test^Patt</Name>
    		<Sex> O </Sex>
    		<Company>
    			<Id> 2.16</Id>
    			<Department>
    				<Id> 2.16.124</Id>
    				<Project>
    					<Id> 2.16.124.113543</Id>
    				</Project>
    			</Department>
    		</Company>
    	</Employee>
    </Employees>
    ";
    
    // read the xml into the class
    var doc = XDocument.Parse(xml);
    var data = (from row in doc.Root.Elements("Employee")
    			let company = row.Element("Company")
    			let dept = company.Element("Department")
    			let project = dept.Element("Project")
    			select new Employee
    			{
    				Id = row.Element("Id").Value.Trim(),
    				Name = row.Element("Name").Value.Trim(),
    				Sex = row.Element("Sex").Value.Trim(),
    				Company = new Company
    				{
    					Id = company.Element("Id").Value.Trim(),
    					Department = new Department
    					{
    						Id = dept.Element("Id").Value.Trim(),
    						Project = new Project
    						{
    							Id = project.Element("Id").Value.Trim()
    						}
    					}
    				}
    			});
    // now you have a collection of 'employees', bind them..

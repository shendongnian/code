    public class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Employed { get; set; }
    }
    List<Employee> empList = new List<Employee>();
    empList.Add(new Employee() { Name = "Andy", Title = "CEO", Employed = true });
    empList.Add(new Employee() { Name = "Bill", Title = "HR", Employed = true });
    empList.Add(new Employee() { Name = "Carl", Title = "Janitor", Employed = false });
    var firedemplist = empList.Where(x => x.Employed == false);
    var newemplist = empList.Except(firedemplist);

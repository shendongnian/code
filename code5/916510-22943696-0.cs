    public class Foo
    {
        private List<Employee> _fooEmployees = new List<Employee>();
        public List<Employee> FooEmployees
        {
            get { return _fooEmployees; }
            set { _fooEmployees = value; }
        }
    //...
    }
    public class ViewModel
    {
       public ObservableCollection<Employee> FooEmployees {get;set;}
       //....
    }
    //...
       var dto = JsonConvert.DeserializeObject<Foo>(json);
       var vm = new ViewModel{FooEmployees = dto.Employees};

    public class Person
    {
        public string Name {get; set;}
    }
    
    public class PersonViewModel
    {
        public string Text {get; set;}
    
        public static implicit operator PersonViewModel(Person dm)
        {
            var vm = new PersonViewModel { Text = dm.Name };
            return vm;
        }
    
        public static implicit operator Person(PersonViewModel vm)
        {
            var dm = new Person { Name = vm.Text };
            return dm;
        }
    }

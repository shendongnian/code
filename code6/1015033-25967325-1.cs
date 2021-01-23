    //this in main or whetever you use it.
    Employee n1 = new Employee();
    Employee manager = new Employee();
    manager.IsCEO = true;
    manager.Name = "Manager Name";
    
    n1.Name = "John";
    n1.Manager = manager;
    
    
    class Employee
    {
        private Employee _manager = new Employee();
        
        public string Name { get; set; }
        
        public bool IsCEO{ get; set;}
    
        public Employee Manager 
        { 
           get
           {
                if(IsCEO)
                   return null;
                else
                   return _manager;
           } 
           else
                if(!IsCEO)
                   _manager=value;
        }   
    
    }

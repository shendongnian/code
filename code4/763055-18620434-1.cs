    class Service
    {
        public void DoSomething() 
        {
            // business logic here 
        } 
    }
    class Child : Form
    {
        Service m_service;
        public Child(Service service)
        {
            m_service = service;
        }
        void Foo()
        {
            // call the business logic
            m_service.DoSomething();
        }
    }
    ....
    // code in the Parent
    var svc = new Service();
    ....
    var child = new ChildForm(svc);
    child.ShowDialog();
    

    MainClass()
    {
         ChildClass _cc = new ChildClass();
         OtherChild _oc = new OtherChild();
         ChildClass cc = get {return _cc;} set{_cc = value;}
         OtherChild oc = get {return _oc;} set{_oc = value;}
         oc.Parent = this;
         //Set the name property of childclass
         string childName = "some name";
    }
    
    ChildClass()
    {
        public string name {get; set;}
    }
    
    OtherChild()
    {
         //Here i want to get the name property from ChildClass()
         //Doing this will make a new instance of ChildClass,  which will not have the name property set.
         Public MainClass parent {get; set;}
         ChildClass cc = parent.cc; 
    
    }

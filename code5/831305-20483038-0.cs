    void Main()
    {
    	Parent theParent = new Parent();
      	string input = "jack";
      	theParent.Child.Name = input;
    
      	theParent.FirstMethod();
    }
    
    class Parent
        {
            public Child Child = new Child();   //I changed this line.  It was originally only 'public Child Child'
    
            public void FirstMethod()
            {
    			Child.parent = this;
                Child.SecondMethod();
            }
        }
    	
    class Child
    {
       public Parent parent;
       private string name;
    
       public string Name
       {
           get { return name; }
           set { name = value; }
       }
    
       public void SecondMethod()
       {
           Console.WriteLine(parent.Child.Name);
       }
    }

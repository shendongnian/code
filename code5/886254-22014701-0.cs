      class ParentClass
                {
                    public void SomeMethod() { 
                       //bug here 
                    }
                }
        
                class Child:ParentClass
                {
                    new public void SomeMethod() { 
                       // I fixed it 
                    }
                }

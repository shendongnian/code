    class Echodata
    {
        public Class1 newobject; // you don't need to initialize this
    
        public Echodata(Class1 temp)
        {
            this.newobject = temp;
        }
        
        public void DoSOmething() {
            newobject.newArray[0] = "This works just fine";
        }
    }

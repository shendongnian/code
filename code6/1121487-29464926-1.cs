    class echodata
    {
        public Class1 newobject = new Class1();
        public echodata(Class1 temp)
        {
            this.newobject = temp;
        }
        // so now why cant i access newobject.namearray[0] for example?
        // What kind of access do you want?
        public void method1()
        {
            newobject.nameArray[0] = "Jerry";
        }
    }

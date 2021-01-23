    void Main()
    {
        ArrayList al = new ArrayList();
        al.Add(new Person() {Name="Steve", Age=53});
        al.Add(new Person() {Name="Thomas", Age=30});
        
        al.Sort(new PersonComparer());
        
        foreach(Person p in al)
            Console.WriteLine(p.Name + " " + p.Age);
        
    }
    
    class Person
    {
        public string Name;
        public int Age;
    }
    class PersonComparer : IComparer
    {
    
        int IComparer.Compare( Object x, Object y )  
        {
            if (x == null)
                return (y == null) ? 0 : 1;
    
            if (y == null)
                return -1;
        
            Person p1 = x as Person;
            Person p2 = y as Person;
            
            // Uncomment this to sort by Name 
            // return( (new CaseInsensitiveComparer()).Compare( p1.Name, p2.Name) );
            return( p1.Age - p2.Age );
        }
    }

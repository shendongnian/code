    class DelClass
    {
        public delegate string StrDelegate();
        public void StringCon(StrDelegate Fname,StrDelegate Lname) 
        {
            Console.WriteLine(Fname() + " " + Lname());
        }
    }

    class Class
    {
        List<string> names=new list<string>();
        
        public void deleteName(string name)
        {
            names.Remove(names.Single(x => x == name));
        }
    }

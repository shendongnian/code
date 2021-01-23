    public void Read(string name, string info, Type type)
    {
         object temp;
         database.retrieve(name, info, out temp);
         // ...
    }

    public void Read<T>(string name, string info)
    {
         T temp;
         database.retrieve(name, info, out temp);
         // ...
    }

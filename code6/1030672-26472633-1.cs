    class Level01
    {
    Dictionary<string,int> values;
    public level01()
    {
       values.Add("Boxes",3);
       values.Add("MaxPoints",3);
       values.Add("Health",3);
    
    }
     //indexer
    public int this[string s] {get{return values[s];} set {values[s] = value;}}
   
    }

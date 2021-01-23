    class ModelName
    {
        string Name { get; set; }
        string foodType { get; set; }
        //etc...
  
        public void ModelName()
        {
            Name = null;
            foodType = null;
            //etc...
        }
    }
    List<Model> ModelList;
    foreach (line in filename)
    {
        doc = line.Split(',');
        Model.Name = doc[1];
        //etc...

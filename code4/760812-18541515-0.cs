    public class Galaxy
    {
        public Galaxy(string name, string distance)
        {
            Name = name;
            Distance = distance;
        }
        public string Name {get; set;}
        public string Distance {get:set;}
    }
    //...
    var theGalaxies = new List<Galaxy>();
    for (int i=0; i < someArray.Length; i+=2)
        theGalaxies.Add(new Galaxy(someArray[i], someArray[i+1]));

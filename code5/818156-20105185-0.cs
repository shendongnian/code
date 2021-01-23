    enum Continent { Europe, Asia, America }
    public interface IPerson 
    {  
        string Name { get; set; }
        Continent Continent { get; set; }
    }
    public class Asian : IPerson
    {
        public Continent Continent
        {
            get 
            {
               return Continent.Asia;
            }
        }
    }

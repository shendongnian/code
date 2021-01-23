    public class Animals<T>
        where T : Animal
    {
        public List<T> List {get;set;}
    }
    var Cows = new Animals<Cow>();

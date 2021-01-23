    public class Fruit{  }
    public class Banana : Fruit { public int monkey;}
    public class Apple : Fruit { public string shape;}
    
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Fruit>(new Fruit[] {new Banana(), new Apple()});
    
            var serializerSettings = new JsonSerializerSettings{ TypeNameHandling = TypeNameHandling.Auto };
    
            var json = JsonConvert.SerializeObject(list, serializerSettings);
    
            List<Fruit> fruitList = JsonConvert.DeserializeObject<List<Fruit>>(json, serializerSettings);
            List<Banana> bananaList = new List<Banana>();
            List<Apple> appleList = new List<Apple>();
            foreach (var fruit in fruitList)
            {
                if (fruit is Banana) bananaList.Add((Banana) fruit); 
                if (fruit is Apple) appleList.Add((Apple) fruit); 
            }
        }
    }

    public List<Fruit> GetUniqueFruits(List<Fruit> Basket) {
    	var set = new HashSet<Fruit>(Basket, new FruitNameEqualityComparer());
    	return set.ToList();
    }
    
    public class Fruit {
    	public string Name { get; set; }
    	public DateTime RipeTime { get; set; }
    }
    
    class FruitNameEqualityComparer : IEqualityComparer<Fruit> {
    	public int Compare(Fruit a, Fruit b) {
    		return a.Name.CompareTo(b.Name);
    	}
    	
    	public bool Equals(Fruit a, Fruit b) {
    		return a.Name.Equals(b.Name);
    	}
    	
    	public int GetHashCode(Fruit f) {
    		return f.Name.GetHashCode();
    	}
    }

    public class FruitsWithDistinctWeightList : IEnumerable<Fruit>
    {  
        private List<Fruit> internalList;
    
        ... // Constructor etc.
        public void Add(Fruit fruit)
        {
           if (!internalList.Any(f => f.Weight == fruit.Weight))
             internalList.Add(fruit);
        }       
    
        ... // Further impl of IEnumerable<Fruit> or IList<Fruit>
    }

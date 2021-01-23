    public class FruitCollection : Collection<Fruit>
    {
        public FruitCollection Clone()
        {
            return Clone(this);
        }
        public static FruitCollection Clone(FruitCollection fruitCollection)
        {
            var clonedFruitCollection = new FruitCollection();
            // Deep copy the collection instead of copying the reference with MemberwiseClone()
            foreach (var fruit in fruitCollection)
            {
                clonedFruitCollection.Add(fruit);
            }
            return clonedFruitCollection;
        }
    }

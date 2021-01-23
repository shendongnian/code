    public abstract class Foo<T> where T : Fruit
    {
        protected List<ProcessedFruit> processedFruit = new List<ProcessedFruit>();
        public void AddFruit(T o)       
        {
            // Process fruit
            processedFruit.Add(o);
        }
        public void Update()
        {
            // Do base class specific stuff here
            OnUpdate();
        }
        protected abstract void OnUpdate();
    }
    public class AppleBar : Foo<Apple>
    {
        //...
    }

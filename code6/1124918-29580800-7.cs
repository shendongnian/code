    public interface IA
    {
        int GetTheOneAndOnlyNumber(); 
    }
    public abstract class AA
    {
        protected abstract void OnSomethingHappened(string s);
    }
    public class A : AA, IA
    {
        public int GetTheOneAndOnlyNumber()
        {
            return 42;
        }
        protected override void OnSomethingHappened(string s)
        {
            Console.WriteLine(s);
        }
    }

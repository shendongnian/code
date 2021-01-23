    public class SuperBase
    {
    }
    internal class MyBase<T> : SuperBase
    {
    }
    internal class A : MyBase<string>
    {
        public void DoStuff()
        {
            Dictionary<string, SuperBase> _dict = new Dictionary<string, SuperBase>();
            _dict.Add("first", new MyBase<int>());
            _dict.Add("second", new MyBase<object>());
            _dict.Add("third", new MyBase<string>());
        }
    }

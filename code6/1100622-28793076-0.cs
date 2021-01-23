    public class A<T>
    {
        // Which one should be used to auto-infer T from usage?
        // Maybe the integer? Or the bool? Or just the string...?
        // Every choice seems a joke, because it would be absolutely
        // arbitrary and unpredictable...
        public A(int x, string y, bool z)
        {
        }
    }

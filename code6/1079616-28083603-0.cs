    public class Foo
    {
        int b;
        public int GetBar(int a)
        {
            try
            {
                return helperGetBar(a, b);
            }
            catch (DivideByZeroException e)
            {
                throw new InvalidOperationException("...", e); //object has not been initialized correctly.
            } 
        }
        static int helperGetBar(int a, int b)
        {
            return a/b; //Can raise DivideByZeroExpection
        }
    }

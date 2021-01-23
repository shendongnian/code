        public abstract class A
        {
            public int Value = 0;
        }
        public class B : A
        {
            // This hides the Value member from the base type A
            public new int Value = 0;
        }
        static void SetValue(B obj, int value)
        {
            obj.Value = value;
        }
        static void AddToValue(A obj, int value)
        {
            obj.Value += value;
        }
        static void Main(string[] args)
        {
            B obj = new B();
            SetValue(obj, 11);
            AddToValue(obj, 5);
            Console.Out.WriteLine("obj.Value = " + obj.Value);
            Console.Out.WriteLine("((A) obj).Value = " + ((A) obj).Value);
            Console.Out.WriteLine("((B) obj).Value = " + ((B) obj).Value);
        }

    void Main()
    {
        dynamic y = new MyDyn(); // or with this null
        dynamic z = new MyDyn();
        object x = y ?? z;
    }
    public class MyDyn : DynamicObject
    {
        public override bool TryBinaryOperation(
            BinaryOperationBinder binder,
            Object arg,
            out Object result
        )
        {
            Console.WriteLine("Hello world!");
            if (binder.Operation == ExpressionType.Coalesce)
            {
                result = 3;
                return true;
            }
            result = null;
            return true;
        }
    }

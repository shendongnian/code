    public class Param<T>
    {
        private static readonly Func<T, T, T> addMethod;
        static Param()
        {
            try
            {
                ParameterExpression left = Expression.Parameter(typeof (T), "left");
                ParameterExpression right = Expression.Parameter(typeof (T), "right");
                addMethod = Expression.Lambda<Func<T, T, T>>(Expression.Add(left, right), left, right).Compile();
            }
            catch (InvalidOperationException)
            {
                //Eat the exception, no + operator defined :(
            }
        }
        public string param_name;
        public T cnt;
        public Param(T _cnt)
        {
            cnt = _cnt;
        }
        public static Param<T> operator +(Param<T> leftOperand, Param<T> rightOperand)
        {
            if (addMethod != null)
            {
                return new Param<T>(addMethod(leftOperand.cnt, rightOperand.cnt));
            }
            return null;
        }
    }
    private static void Main(string[] args)
    {
        var pi = new Param<int>(5);
        var pi2 = new Param<int>(6);
        var pi3 = pi + pi2;
        var pi4 = new Param<ooject>(5);//Wont work
        var pi5 = new Param<object>(6);
        var pi6 = pi4 + pi5;
    }

        class X
        {
            public string Y { get; set; }
        }
        class Foo1
        {
            public int A { get; set; }
            public X B { get; set; }
        }
        public static void Main()
        {
            var instanceParameter = Expression.Parameter(typeof(Foo1));
            Dictionary<int, Expression> map = new Dictionary<int, Expression>()
            { { 0, Expression.Property(
                       instanceParameter,
                       "A") },
              { 1, Expression.Property(
                       Expression.Property(instanceParameter, "B"),
                       "Y" ) } };
            //more properties can be defined easily
            object[,] data = new object[4, 2];
            data[0, 0] = 1;
            data[0, 1] = "asdf";
            data[1, 0] = 2;
            data[1, 1] = "yyy";
            data[2, 0] = -1;
            data[2, 1] = "xxx";
            data[3, 0] = 3;
            data[3, 1] = "good luck!";
            List<Foo1> result = new List<Foo1>();
            for (int row = 0; row < data.GetLength(0); ++row)
            {
                var foo = new Foo1() { B = new X() };
                for (int col = 0; col < data.GetLength(1); ++col)
                {
                    Expression
                        .Lambda<Action<Foo1>>(
                            Expression.Assign(
                                map[col],
                                Expression.Constant(data[row, col])),
                            instanceParameter)
                        .Compile()(foo);
                }
                result.Add(foo);
            }
        }

    class A
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public A(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public override string ToString()
        {
            return "{" + Name + ", " + Id + "}";
        }
    }
    class B
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public B(int id, string text)
        {
            Id = id;
            Text = text;
        }
        public override string ToString()
        {
            return "{" + Id + ", " + Text + "}";
        }
    }
    class C
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public C(int id, string text)
        {
            Id = id;
            Text = text;
        }
        public override string ToString()
        {
            return "{" + Id + ", " + Text + "}";
        }
    }
    [Flags]
    enum JoinType
    {
        None = 0,
        B = 1,
        C = 2,
        BC = 3
    }
    class Program
    {
        static void Main(string[] args)
        {
            A[] dba =
            {
                new A("A1", 1),
                new A("A2", 2),
                new A("A3", 3)
            };
            B[] dbb =
            {
                new B(1, "B1"),
                new B(2, "B2"),
                new B(3, "B3")
            };
            C[] dbc =
            {
                new C(1, "C1"),
                new C(2, "C2"),
                new C(3, "C3")
            };
            JoinType joinType;
            while ((joinType = _PromptJoinType()) != JoinType.None)
            {
                var query = from x in dba select new { A = x, B = (B)null, C = (C)null };
                if ((joinType & JoinType.B) != 0)
                {
                    query = from x in query
                            join y in dbb on x.A.Id equals y.Id
                            select new { A = x.A, B = y, C = x.C };
                }
                if ((joinType & JoinType.C) != 0)
                {
                    query = from x in query
                            join y in dbc on x.A.Id equals y.Id
                            select new { A = x.A, B = x.B, C = y };
                }
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
        }
        private static JoinType _PromptJoinType()
        {
            JoinType? joinType = null;
            do
            {
                Console.Write("Join type ['A' for all, 'B', 'C', or 'N' for none]");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                case ConsoleKey.A:
                    joinType = JoinType.BC;
                    break;
                case ConsoleKey.B:
                    joinType = JoinType.B;
                    break;
                case ConsoleKey.C:
                    joinType = JoinType.C;
                    break;
                case ConsoleKey.N:
                    joinType = JoinType.None;
                    break;
                default:
                    break;
                }
            } while (joinType == null);
            return joinType.Value;
        }
    }

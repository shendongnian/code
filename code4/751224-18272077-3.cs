    abstract class Base
    {
        public static int FieldCount { get { return -1; } }
    }
    class Node : Base
    {
        int x, y, z; // has three fields, so:
        public new static int FieldCount { get { return 3; } }
    }
    class Way : Base
    {
        int w, x, y, z; // has four fields, so:
        public new static int FieldCount { get { return 4; } }
    }
    ...
    Console.WriteLine(Base.FieldCount) // -1
    Console.WriteLine(Node.FieldCount) // 3
    Console.WriteLine(Way.FieldCount) // 4
  

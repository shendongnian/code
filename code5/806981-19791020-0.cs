    namespace Test1
    {
        class Node<T>
        {
            public T Test()
            {
                return default(T);
            }
        }
    }
    
    namespace Test1
    {
        using NodeSteps = System.Tuple<Node<string>, int>;
    
        public class Class1
        {
             public static void Main()
             {
                NodeSteps t1 = new NodeSteps(new Node<string>(), 10);
                t1.Item1.Test();
             }
        }
    }

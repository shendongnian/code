    using System;
    
    class YourEnclosingType
    {
        static void Main()
        {
            Type type = Type.GetType("m_msgTypeVersion");
            object[] args = null; // no args
            typeof(YourEnclosingType).GetMethod("EvilHack").MakeGenericMethod(type)
                        .Invoke(null, args);
        }
        public static void EvilHack<T>()
        {
            T myObject = Activator.CreateInstance<T>();
            Serializer<T> serUtilmd51 = new Serializer<T>();
            serUtilmd51.DoIt(myObject);
        }
    }
    class m_msgTypeVersion // worst. name. ever
    { }
    class Serializer<T>
    {
        public void DoIt(T obj)
        {
            Console.WriteLine("I'm serializing " + obj);
        }
    }

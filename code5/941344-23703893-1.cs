    public static void WriteMessage<T>(T objectA) where T : IHasTwoMethods
        {
            var text = objectA.MethodTwo();  //Will work
            Console.WriteLine("Text:{0}", text);
        }

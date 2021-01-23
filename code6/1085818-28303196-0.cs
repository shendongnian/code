    var stack = new Stack();
    var fieldInfo = typeof(Stack).GetField("_array", BindingFlags.NonPublic | BindingFlags.Instance);
    Console.WriteLine((fieldInfo.GetValue(stack) as object[]).Length); // 10
    var genericStack = new Stack<int>();
    var genericFieldInfo = typeof(Stack<int>).GetField("_array", BindingFlags.NonPublic | BindingFlags.Instance);
    Console.WriteLine((genericFieldInfo.GetValue(genericStack) as int[]).Length); // 0

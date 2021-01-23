    public static string ConvertResultToString(ArOpDel del)
    {
         string result = String.Format("The result of the {0} operation is {1}", del.Method.Name, del(10, 5).ToString());
         return result;
    }
...
    Console.WriteLine(ArithmeticOperation.ConvertResultToString(additionDelegate));

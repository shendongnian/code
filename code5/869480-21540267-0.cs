    List<int> userInput = new List<int>();
    for (int i = 0; i < selection.Count(); i++)
    {
     var int32 = Convert.ToInt32(Console.ReadLine());
     userInput.Add(int32);
    }
    Console.WriteLine(userInput.Intersect(selection).Count() == selection.Count ? "correct" : "wrong");

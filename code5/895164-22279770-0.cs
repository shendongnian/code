    int inputs[] = {0, 0};
    
    for(int index = 0; index < 2; index++) {
      Console.WriteLine("Give me a number.");
      inputs[index] = Convert.ToInt32(Console.ReadLine());
    }
    
    Console.WriteLine("{0}", inputs.Sum());

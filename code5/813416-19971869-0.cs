    string result = "Overfishing, erosion and warmer waters are feeding jellyfish blooms in coastal regions worldwide. And they're causing damage";
    var array = result.Split(new string[] {",", ".", " "}, StringSplitOptions.RemoveEmptyEntries);
    foreach (var item in array)
    {
       if(item.Length >= 4 && item.Length < 10)
          Console.WriteLine(item);
    }

    int  number;
    string value;
    do
    {
      Console.Write("Enter a number : ");
      value =Console.ReadLine();
      if (!Int32.TryParse(value, out number))
           {
             Console.WriteLine("Wrong Input!!!!");
           }
    }while (!Int32.TryParse(value, out number));

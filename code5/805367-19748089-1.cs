       Console.WriteLine("Enter first number: ");
       double num1, num2;
       double.TryParse(Console.ReadLine(), out num1); // double.TryParse() method also returns a bool, so you could flag an error to the user here
       Console.WriteLine("Enter second number: ");
       double.TryParse(Console.ReadLine(), out num2);

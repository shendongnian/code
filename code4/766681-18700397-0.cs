         Console.WriteLine("Enter parameters for the function with a space in between each parameter: "); String stringParameters = Console.ReadLine();
         String[] parametersStringArray = stringParameters.Split(' ');
         Object[] parametersArray = new Object[parametersStringArray.Length];
         for (int i = 0; i < parametersStringArray.Length; i++)
         {
            int tmp;
            if (int.TryParse(parametersStringArray[i], out tmp))
               parametersArray[i] = tmp;
         }

    List<int> doneNumbers = new List<int>();
    for (int i = 0; i < array.Length - 1; i++)
    {
        if(!doneNumbers.Contains(array[i]))
        {
            int currentNumber = array[i];
            int count = 0;
            for (int j = i; j < array.Length; j++)
            {
                if(currentNumber == array[j])
                {
                    count++;
                }
            }
            Console.WriteLine("\t\n " + currentNumber +" "+ " occurs " + " "+count + " "+" times");
            doneNumbers.Add(currentNumber);
            Console.ReadKey();
          }
       }
    }
  }
}

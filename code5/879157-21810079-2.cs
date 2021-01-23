    private void FilterNumbers(List<string> numbers)
    {
       int number;
       for (int i = 0; i < numbers.Count; i++)
       {
          if(Int32.TryParse(numbers[i],out number))
          {
             numbers.Remove(numbers[i]);
          }
        }
     }

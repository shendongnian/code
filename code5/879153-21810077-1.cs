    private void FilterNumbers(List<string> numbers)
    {
       for(int i = 0; i < numbers.Count; i++)
       {
           if(numbers[i].All(Char.IsDigit))
           {
              numbers.RemoveAt(i);
           }
       }
    }

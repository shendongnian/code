    private void showTotal(params int[] numbers)
    {
      if(numbers != null)
      {
        int sum = numbers.Sum();
        result.Text = sum.ToString();
      }
    }

    List<int> numbers = new List<int>();
    private void Submit_Click(...)
    {
       numbers.Add(int.Parse(UsrInputBox.Text));
    }
    
    private void Calculate_Click(...)
    {
       int smallest = numbers.Min();
       int largest = numbers.Max();
    
       //Display code
    }

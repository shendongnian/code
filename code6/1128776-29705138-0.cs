    private Random rng = new Random();
    private List<int> numbers = new List<int>();
    private void Form_Loaded(...) //Set to Form's Loaded event
    {
            number.Add(1);
            number.Add(2);
            number.Add(3);
            number.Add(4);
            number.Add(5);
            number.Add(6);
            number.Add(7);
            number.Add(8);
            number.Add(9);
            number.Add(10);
    }
    
    private void button1_click(...)
    {
         tempValue = rng.Next(0, number.Count);
         label1.Text = number[tempValue].ToString();
         number.Remove(number[tempValue]);
    }

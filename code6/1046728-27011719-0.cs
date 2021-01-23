    DateTime userInput;
    bool result = DateTime.TryParse(this.dpSave.Text, out userInput);
    if (result)
    {
       long ticks = userInput.Ticks;
       System.IO.File.WriteAllText(@"D:\folder\Ticks.txt", ticks.ToString());
     }
     else
     {
       MessageBox.Show("Date time parse failed");
     }

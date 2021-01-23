    if (System.IO.File.Exists(@"D:\folder\Ticks.txt"))
    {
       string contents = System.IO.File.ReadAllText(@"D:\Sandeep\Ticks.txt");
       long ticks;
       if (long.TryParse(contents, out ticks))
       {
         DateTime storedDateTime = new DateTime(ticks);
         MessageBox.Show("Stored Date" + storedDateTime.ToShortDateString());
       }
       else
       {
         MessageBox.Show("Unable to obtain stored dates");
       }
    }

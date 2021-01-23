    public void Customer1Total()
    {
        for(int i = 0; i <= 2; i++)
        {
            total1 += Invoice.Total[i];            
        }
        //Move write line outside the loop
        Console.WriteLine(String.Format("\nTotal of Customer 1:{0:C}", total1));
    }

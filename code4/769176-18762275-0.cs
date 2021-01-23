    serialPort1.Write(Data, 0, Data.Length);
    
    System.Threading.Thread.Sleep(500);
    
    try
    {
    	serialPort1.Read(Data2, 0, Data2.Length);
    }
    catch (TimeoutException)
    {
    	errorProvider1.SetError(maskedTextBox1, "timeout");
    }
    catch (ArgumentNullException)
    {
    	errorProvider1.SetError(maskedTextBox1, "no answer");
    }

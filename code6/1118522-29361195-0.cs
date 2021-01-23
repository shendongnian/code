    MyDuplexSettings.DuplexSettings ds = new MyDuplexSettings.DuplexSettings();
    short status = 0;
    string errorMessage = string.Empty;
    status = ds.GetPrinterDuplex("<<Printer Name>>", out errorMessage);
    if (status == 0)
    {
    //Console.WriteLine("Error occured. Error Message is : " + errorMessage);
    //Some error occured, errorMessage is available in string errorMessage
    }
    else
    {
     //Console.WriteLine("Current Duplex Setting is : " & status);
     //Call successfull, Current duplex flag is set to status
    }
 
    status = 2; //set duplex flag to 2
    ds.SetPrinterDuplex("<<Printer Name>>", status, out errorMessage);

        var server = new PrintServer(printDialog.PrintQueue.HostingPrintServer.Name);
        var printQueue = server.GetPrintQueue(printDialog.PrintQueue.Name);
        printQueue.UserPrintTicket = GetPrintTicket();
        
        PrintUsingXpsDocWriter(printQueue);
        }
        private void PrintUsingXpsDocWriter(PrintQueue printQueue)
        {
        	var docWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
        	int index = 0;
        	foreach (var printFileName in new DirectoryInfo(printingPath).EnumerateFiles("*.xps"))
        	{
        		
        	}
        	printQueue.Dispose();
        }
        
        private PrintTicket GetPrintTicket()
        {
        // This file had serialized print ticket settings
                    var reader = new FileStream(@"C:\temp\printTicket.xml", FileMode.Open);
                    var ticket = new PrintTicket(reader);
                    reader.Close();
                    return ticket;
        }
    

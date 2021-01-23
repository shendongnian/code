    private void GenerateInvoices()
    {
       Task.Run(()=>
        {
            ProgressMessages = "Starting execution of Generate Invoices on the HBApp Server";
            int numGenerated = GenerateInvoices(masterProcessId);  // runs for a few seconds
            ProgressMessages += "\n" + numGenerated.ToString() + " invoices have been generated.";
        });
    }

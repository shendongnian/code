        textBox1.Clear();
        var startInfo = new ProcessStartInfo("phing");
        startInfo.WorkingDirectory = @"C:\wamp\bin\php\php5.4.3";
        // startInfo.Arguments = "commit > log.txt"; // DONT PUT OUTPUT TO FILE
        startInfo.Arguments = "commit"; // we will read output with event
        string pergunta = inputbox.InputBox("Qual é a mensagem do Commit ?", "Commit", "Mensagem Commit");
        // textBox1.Text = "Escreva o caminho de origem da pasta:";
        Process proc = Process.Start(startInfo);
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardInput = true;
        // not like this
        // proc.WaitForExit();
        // using (StreamReader sr = new StreamReader(@"C:\wamp\bin\php\php5.4.3\log.txt"))
        // {
        //    textBox1.Text = sr.ReadToEnd();
        // }
        // add handler
        // this will "assign" a function (proc_OutputDataReceived - you can change name)
        // that will be called when proc.OutputDataReceived event will occur
        // for that kind of event - you have to use DataReceivedEventHandler event type
        proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived);
        
    // event handler function (outside function that you pasted)
    // this function is assigned to proc.OutputDataReceived event
    // by code with "+= new..."
    // "sender" is an object in which event occured (when it occurs - "proc" will be available as "sender" here)
    // "e" is an object with event parameters (data sent from process and some more)
    public void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        // cast "sender" to Process type
        // "sender" is Process, but it has "object" type, 
        // you have to cast it to use .StandardInput.WriteLine() on "sender"
        Process callerProcess = (Process)sender; 
        MessageBox.Show(e.Data); // this will show text that process sent
        MessageBox.Show(e.Data.ToString()); // you may need to add ToString(), im not sure
        
        if (e.Data.StartsWith("Revisao do Commit numero"))
        {
            MessageBox.Show("Process is talking something about Revisao numero"); // :)
            callerProcess.StandardInput.WriteLine("Yes! Numero!"); // reply "Yes! Numero!" to process
        }
    }

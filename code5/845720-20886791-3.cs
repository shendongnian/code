    Process process = new Process();
    process.StartInfo.FileName = "winsat" ;
    //in here you add as many parameters as needed
    process.StartInfo.Arguments = "formal" ; 
    process.Start();

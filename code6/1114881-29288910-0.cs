    process.Start();
    StreamWriter processInputStream = process.StandardInput;
    do {
        String inputText = Console.ReadLine():
        processInputStream.write(inputText);
    while(!process.HasExited)
    process.WaitForExit();

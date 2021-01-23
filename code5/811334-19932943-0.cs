    string file = File.ReadAllText(@"C:\Users\path.......");
            //The code wrote to the right hand side finds the file listed from my C drive
     string longstr = file;
    string[] strs = longstr.Split(':', '*');
    foreach (string ss in strs)
            {
                Console.WriteLine(ss);
            }
    string file = File.AppendAllText(@"C:\Users\path\.......");
            Console.ReadLine();

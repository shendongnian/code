        string slInput;
        Console.Write("Please enter the input name: ");
        string sOpen = Console.ReadLine();
        sOpen = sOpen + ".txt";
        if(!File.Exists(sOpen))
        {
            Console.WriteLine("Input file doesn't exist");
            return;  // Exit or put some kind of retry to ask again the input file
        }
        Console.WriteLine();
        Console.Write("Please enter the output name: ");
        string sSave = Console.ReadLine();
        sSave = sSave + ".txt";
 
       try
       {
            using(StreamReader srRead = new StreamReader(sOpen))
            using(StreamWrite swWrite = new StreamWriter(sSave))
            {
                while ((slInput = srRead.ReadLine()) != null)
                {
                    double dDoub = double.Parse(slInput);
                    dDoub = dDoub * 2;
                    swWrite.WriteLine(dDoub);
                }
            }
        }
        catch (Exception e)
        {
             Console.WriteLine("Error! {0}", e.Message);
        }

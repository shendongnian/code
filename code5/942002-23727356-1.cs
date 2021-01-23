    public void WriteFile(string line, string fileName)
    {
        try
        {
            using(var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            using(var sw = new StreamWriter(fs))
            {
                sw.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Cannot open Redirect.txt for writing");
            Console.WriteLine(e.Message);
            return;
        }
        Console.WriteLine("Done");
    }

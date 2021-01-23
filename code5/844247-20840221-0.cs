    using System.IO;
    ...
    public static bool CreateFile(string file)
    {
        using (var writer = File.CreateText(file))
        {
            try
            {
                writer.WriteLine("something ");
            }
            catch (IOException e)
            {
                // TODO: Change the handling of this. It's weird at the moment
                Console.Write(e.Message);
                Console.ReadLine();
                return false;
            }
        }
        return true;            
    }

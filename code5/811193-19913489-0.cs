    static void DirSearch(string path, ref int count)
    {
        try
        {
            foreach (string dirPath in Directory.GetDirectories(path))
            {
                foreach (string filePath in Directory.GetFiles(dirPath))
                {
                    string filename = Path.GetFileName(filePath);
                    if (filename.Equals("desktop.txt"))
                    {
                        File.Delete(filePath);
                        count++
                    }
                    Console.WriteLine(filePath); // print files
                }
                Console.WriteLine(dirPath); // print directories
                DirSearch(dirPath);
            }
        }
        catch (System.Exception excpt)
        {
            Console.WriteLine(excpt.Message);
        }
    }

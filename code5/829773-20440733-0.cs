           int getCharCount(String PathS)        
            {
                Console.WriteLine("Enter Char to be searched!");
                char CharacterSearch = Console.ReadKey().KeyChar;
                Console.ReadLine();
                int count = 0;
                String content=File.ReadAllText(PathS);
                for (int i = 0; i < content.Length; i++)
                {
                    
                    if (content[i].ToString().ToLower().Equals(CharacterSearch.ToString().ToLower()))
                        count++;
                }
                return count;
            }
    class Program
    {
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Introduceti un path pentru fisierul text care vreti sa il deschideti: ");
        String PathS = Console.ReadLine();
        GetStatistics G = new GetStatistics();
        Console.WriteLine(G.GetFileDetails(PathS));
        Console.WriteLine(G.ReadFromFile(PathS));
        Console.WriteLine("Serch Count ="+G.getCharCount(PathS));
    }
    }

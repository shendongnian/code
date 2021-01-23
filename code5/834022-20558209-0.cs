    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            bool bFichierExiste = false;
            string sPhrase = "";
            bFichierExiste = File.Exists("ecrire.txt"); //Validate if file exist
            if (!bFichierExiste)
            {
                Console.WriteLine("N'existe pas!");
            }
            else
            {
                StreamWriter fichier = new StreamWriter("ecrire.txt");
                using (fichier)
                {
                    do
                    {
                        sPhrase = Console.ReadLine();
                        Console.WriteLine(sPhrase);
                        fichier.WriteLine(sPhrase);
                        fichier.Flush();
                    }
                    while (sPhrase != "FIN");
                }
                fichier.Close();
            }
            Console.ReadKey();
        }
    }
    }

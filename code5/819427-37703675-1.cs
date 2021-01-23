    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReadFile
    {
        class Program
        {
            static void ReadFile(string filePath, List<string> custumerNames, List<int> phoneNumbers)
            {
                string line = string.Empty;
                var fileStream = new StreamReader(filePath);
                bool isPhoneNumber = true;
    
                while ((line = fileStream.ReadLine()) != null)
                {
                    if (isPhoneNumber)
                    {
                        phoneNumbers.Add(Convert.ToInt32(line));
                        isPhoneNumber = false;
                    }
                    else
                    {
                        custumerNames.Add(line);
                        isPhoneNumber = true;
                    }
                }
    
                fileStream.Close();
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine("Started reading the file...");
                List<string> custumersNamesList = new List<string>();
                List<int> custumersPhonesNumbers = new List<int>();
    
                ReadFile("SampleFile.txt", custumersNamesList, custumersPhonesNumbers);
    
                //Assuming both the list's has same lenght.
                for (int i = 0; i < custumersNamesList.Count(); i++)
                {
                    Console.WriteLine(string.Format("Custumer Name: {0} , Custumer Phone Number: {1}",
                        custumersNamesList[i], Convert.ToString(custumersPhonesNumbers[i])));
                }
    
                Console.ReadLine();
            }
        }
    }

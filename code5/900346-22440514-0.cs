            try
            {
                double factor, endResult, amount;
                string[] fileLines;
                StreamReader unitsOfMeasurement = new StreamReader("../../convert.txt"); //Reads the convert.txt file
                Console.WriteLine("convert.txt has uploaded");
                fileLines = unitsOfMeasurement.ReadToEnd().Replace("\r\n", "\n").Split('\n');//place file lines in an array of string
                //Get inputs
                Console.WriteLine("\nPlease input the amount, to and from type (Ex. 5,ounce,gram):");
                string userInput = Console.ReadLine();
                bool blnFound = false;
                for (int i = 0; i < fileLines.Length; i++)
                {
                    string[] filter = userInput.Split(',');
                    
                    if ((filter.Length == 3) && (filter[1].Trim() == fileLines[i].Split(',')[0].Trim()))
                    {
                        blnFound = true;
                        Console.WriteLine(fileLines[i]);
                        factor = Convert.ToDouble(fileLines[i].Split(',')[2]);
                        amount = Convert.ToDouble(filter[0]);
                        endResult = (factor * amount);
                        Console.WriteLine("\n{0} {1} equals {2} {3}", amount, filter[1], endResult, filter[2]);
                        Console.ReadLine();
                        break;
                    }
                }
                if (blnFound == false)
                {
                    Console.WriteLine("Not Matched");
                    Console.ReadLine();
                }
                unitsOfMeasurement.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

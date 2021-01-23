    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Input_Cell_details_to_Array
    {
        class Program
        {
            static void Main(string[] args)
            {
                //string[] CellDataHeaders = new string[7] { "CellID", "Sample", "WriteTX", "Depass", "DischargeDate", "Discharge" };
                Console.WriteLine("Enter values for Cell ID (CellType_Serial_LoadType_Term), Sample, Write/TX, Depass, Discharge Date (dd/mm/yyyy) and Discharge load.");
                String[,] CellDetailArray = new String[16, 7];
                for (int i = 0; i < CellDetailArray.GetLength(0); i++)
                {
                    string[] CellDataHeaders = new string[7] { "Cell ID", "Quiescent", "Sample", "WriteTX", "Depass", "DischargeDate", "Discharge" };
                    Console.WriteLine("####################################################################################################");
                    Console.WriteLine("");
                    Console.WriteLine(string.Format("Data for row no. {0}:", i + 1));
                    for (int j = 0; j < CellDetailArray.GetLength(1); j++)
                    {
                        Console.Write(CellDataHeaders[j]);
                        Console.Write(string.Format("\tValue for column no. {0}: ", j + 1));
                        CellDetailArray[i, j] = Console.ReadLine();
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("========================================================================================================");
                Console.WriteLine("Data entry finished.\n\n Cell Detail Array contents:");
                for (int i = 0; i < CellDetailArray.GetLength(0); i++)
                {
                    Console.Write(string.Format("\nRow no. {0}: ", i + 1));
                    for (int j = 0; j < CellDetailArray.GetLength(1); j++)
                    {
                        Console.Write(string.Format("\"{0}\"", CellDetailArray[i, j]));
                        if (j < CellDetailArray.GetLength(1) - 1)
                            Console.Write(", ");
                    }
                    Console.ReadLine();
                }
            }
        }
    }

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable inputDataTable = CreateInputDataTable();
                Console.WriteLine("Input data table: ");
                PrintDataTable(inputDataTable);
                DataTable outputDataTable = CustomSortDataTable(inputDataTable);
                Console.WriteLine("Sorted data table: ");
                PrintDataTable(outputDataTable);
            }
    
            private static DataTable CustomSortDataTable(DataTable inputDataTable)
            {
                DataRow[] rows = inputDataTable.Select();
                IComparer<string> animalTypeComparer = new AnimalTypeComparer();
    
                IEnumerable<DataRow> sortedRows = rows.OrderBy(x => x["AnimalType"].ToString(), animalTypeComparer);
    
                DataTable result = new DataTable();
    
                result.Columns.Add("ID");
                result.Columns.Add("AnimalType");
    
                foreach(DataRow row in sortedRows)
                {
                    result.ImportRow(row);
                }
    
                return result;
            }
    
            private static void PrintDataTable(DataTable inputDataTable)
            {
                foreach(DataRow row in inputDataTable.Rows)
                {
                    Console.WriteLine("({0}, {1})", row["ID"], row["AnimalType"]);
                }
            }
    
            private static DataTable CreateInputDataTable()
            {
                DataTable result = new DataTable();
    
                result.Columns.Add("ID");
                result.Columns.Add("AnimalType");
    
                DataRow toInsert = result.NewRow();
    
                toInsert["ID"] = 1;
                toInsert["AnimalType"] = "Cat";
                result.Rows.Add(toInsert);
    
                toInsert = result.NewRow();
                toInsert["ID"] = 2;
                toInsert["AnimalType"] = "Cat";
                result.Rows.Add(toInsert);
    
                toInsert = result.NewRow();
                toInsert["ID"] = 3;
                toInsert["AnimalType"] = "Bird";
                result.Rows.Add(toInsert);
    
                toInsert = result.NewRow();
                toInsert["ID"] = 4;
                toInsert["AnimalType"] = "Bird";
                result.Rows.Add(toInsert);
    
                toInsert = result.NewRow();
                toInsert["ID"] = 5;
                toInsert["AnimalType"] = "Dog";
                result.Rows.Add(toInsert);
    
                toInsert = result.NewRow();
                toInsert["ID"] = 6;
                toInsert["AnimalType"] = "Dog";
                result.Rows.Add(toInsert);
    
                toInsert = result.NewRow();
                toInsert["ID"] = 7;
                toInsert["AnimalType"] = "Hamster";
                result.Rows.Add(toInsert);
    
                toInsert = result.NewRow();
                toInsert["ID"] = 8;
                toInsert["AnimalType"] = "Hamster";
                result.Rows.Add(toInsert);
    
                return result;
            }
        }
    
        class AnimalTypeComparer : IComparer<string>
        {
            private static readonly string[] AnimalTypes = {"Hamster", "Bird", "Cat", "Dog"};
            #region Implementation of IComparer<in string>
    
            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <returns>
            /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
            /// </returns>
            /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
            public int Compare(string x, string y)
            {
                return Array.IndexOf(AnimalTypes, x).CompareTo(Array.IndexOf(AnimalTypes, y));
            }
    
            #endregion
        }
    }

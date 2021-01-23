    using System.Collections.Generic;
    using System.Linq;
    
    namespace ReverseOrder
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> list = new List<string>();
                list.Add("3 5 7 2");
                list.Add("13 15 17 12");
                list.Add("23 25 27 22");
    
                int numberOfValuesPerLine = list[0].Split(' ').Count();
    
                List<string> result = new List<string>();
    
                for (int j = 0; j < numberOfValuesPerLine; j++)
                {
                    for (int i = 0; i < list.Count; i++)
                    {                    
                        string[] stringArray = list[i].Split(' ');
                        result.Add(stringArray[j]);    
                    }                    
                }
            }
        }
    }

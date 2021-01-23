    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace FileToIntList
    {
    class Program
    {
        static void Main(string[] args)
        {
            // Read the file as one string.
            System.IO.StreamReader myFile =
               new System.IO.StreamReader("C:\\Users\\M.M.S.I\\Desktop\\test.txt");
            string myString = myFile.ReadToEnd();
            myFile.Close();
            // Display the file contents.
            //Console.WriteLine(myString);
            char rc = (char)10;
            String[] listLines = myString.Split(rc);
            List<List<int>> listArrays = new List<List<int>>();
            for (int i = 0; i < listLines.Length; i++)
            {
                List<int> array = new List<int>();
                String[] listInts = listLines[i].Split(' ');
                for(int j=0;j<listInts.Length;j++)
                {
                    if (listInts[j] != "\r")
                    {
                        array.Add(Convert.ToInt32(listInts[j]));
                    }
                }
                listArrays.Add(array);
            }
                
            foreach(List<int> array in listArrays){
                foreach (int i in array)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
    }

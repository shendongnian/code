    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace lab25LEA
    {
        class Program
        {
            const int MAX = 50; 
    
            static void Main(string[] args)
            {
                // In your program create an array of 50 integers
                // to hold the data that comes from the file.
                int[] numbers = new int[MAX];
    
                // Your program must get the path to the user's Documents folder as described in the reading material on File Paths.
                // The name of the file will be "grades.txt". Code this file name right in your program. 
                // No user input is required to get the file name.
    
                // Create a StreamReader object, 
                // using this path. This will open the file.
                StreamReader data = new StreamReader("grades.txt");
                string fromFile;
                int count = 0;
    
                // Write a loop that reads data from the file, 
                // until it discovers the end of the file.
                fromFile = data.ReadLine();
                while (fromFile != null){
                    // As each integer value is read in, display it, and store it in the array.
                    if (fromFile != null)
                    {
                        // Using the concepts taught earlier about partially filled arrays, 
                        // write a method that takes the array as a parameter and calculates and returns the average 
                        // value of the integers stored in the array
                        int[] dataArray = fromFile.Split(" ");
    
                        numbers[count] = Convert.ToInt32(dataArray[1]);
                        count++;
                        fromFile = data.ReadLine();
                    }
                }
    
                // Output the average.
                AverageScore(numbers);
    
                Console.ReadLine();
            }
    
            static void AverageScore(int[] numbers)
            {
                int sum=0;
                int average=0;
                if(numbers.length > 0){
                     sum = numbers.Sum();
                     average = sum / numbers.Length;
                }
                Console.WriteLine("Average is :{0}",average);
            }
        }
    }

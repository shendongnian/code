     static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\test.txt");
            string[] firstArray = new string[7];
            string[] secondArry = new string[4];
            string[] thirdArry = new string[4];
            int i = 0, index = 0;
            foreach (var item in lines)
            {
                var date = item.Trim(new char[] { ':' });
                DateTime dt;
                
                if (DateTime.TryParse(date, out dt))
                {
                    i = 0;
                    index = index + 1;
                }
                else
                {
                    if (index == 1)
                        firstArray[i] = item.ToString();
                    if (index == 2)
                        secondArry[i] = item.ToString();
                    if (index == 3)
                        thirdArry[i] = item.ToString();
                    i++;
                }
            }
            foreach (var array1 in firstArray)
            {
                Console.WriteLine(array1.ToString());
            }
            foreach (var array2 in secondArry)
            {
                Console.WriteLine(array2.ToString());
            }
            foreach (var array3 in thirdArry)
            {
                Console.WriteLine(array3.ToString());
            }
        }
 

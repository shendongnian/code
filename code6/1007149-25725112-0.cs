         static void Main(string[] args)
         {
            string input = "LOREM IPSUM DOLOR 0,5 SIT Amet consectetur adipiscing elit";
            string[] arr = input.Split(' ');            
            List<string> splitList = new List<string>();
            int loc = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (isFound(arr[i]))
                {
                    loc = input.IndexOf(arr[i]);
                    splitList.Add(input.Substring(0, loc));
                    input = input.Substring(loc);
                }
            }
            splitList.Add(input);
            //splitList is the list of splited string
         }
        static bool isFound(string str)
        {
            bool result = false;
            if ((str[0] > 64 && str[0] < 91)  ||  (str[0] > 47 && str[0] < 58))
            {
                if (str.Count(x => (x > 96 && x < 123)) > 0)
                {
                    result = true;
                }
            }            
            return result;
        }

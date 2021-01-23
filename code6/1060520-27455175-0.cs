      static void Main(string[] args)
        {
            var tempList = new List<string>();
            tempList.Add("1");
            tempList.Add("2");
            int x;
            for (x = 0; x < tempList.Count; x++)
            {
                //do something here
            }
            //value of x after loop
            Console.WriteLine(x);
            //the value of x is 2.
            try
            {
                Console.WriteLine(tempList[x]); //lets try to read the value here
            }catch(Exception e){
                Console.WriteLine("nope, not happening");
            }
            //to drive this point further home... let me show you what you did...
            tempList.Add("random");
            try
            {
                Console.WriteLine(tempList[x+1]); //lets try to read the value here after we added an element
            }
            catch (Exception e)
            {
                Console.WriteLine("nope, not happening");
            }
            Console.ReadLine();
        }

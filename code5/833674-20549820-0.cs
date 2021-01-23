        //A class to hold the individual pieces of data
        public class Item
        {
            public string Name = "";
            public int Qty = 0;
            public double Price = 0;
            public int QtySold = 0;
        }
        public Item FindItem(string filename, string itemname)
        {
            //An object of type Item that will hold the specific values
            Item output = new Item();
            //The using block handles automatic disposal of the streamreader
            using(StreamReader sr = new StreamReader(filename))
            {
                //Read the file until the end is reached
                while(!sr.EndOfStream)
                {
                    //Check the string from the file against the item name you're
                    //looking for.
                    string temp = sr.ReadLine().Trim();
                    if(temp == itemname)
                    {
                        //Once we find it, throw away the empty line and start
                        //assigning the data to the output object.
                        sr.ReadLine();
                        output.Name = temp;
                        output.Qty = int.Parse(sr.ReadLine());
                        output.Price = double.Parse(sr.ReadLine());
                        output.QtySold = int.Parse(sr.ReadLine());
                        //Since we found the item we're looking, there's no need
                        //to keep looping
                        break;
                    }
                }
            }
            //The file is closed and output will either have real data or an empty
            //name and the rest all 0's
            return output;
        }

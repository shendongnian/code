        static void Main(string[] args)
        {
            
            Random r = new Random();
            for (int k = 0; k < 4; k++) {
                i[k] = new items(r.Next());
            }
            foreach(items it in i){
                Console.WriteLine("The item name {0} and the Id is {1}",it.name,it.ID);
            }
            var i= items[4];
            i.ID=6;// NOW YOU CAN ACCCESS IT
            //OR SIMPLY 
            items[4].ID=6;
        }

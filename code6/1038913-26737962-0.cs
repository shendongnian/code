    public void DisplayItems() // Displays items in list
        {
            Link temp = list;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
        public int NumberOfItems() // returns number of items in list
        {
            Link temp = list;
            int i = 0;
            while (temp != null) 
            {
                temp = temp.Next;
                i++;
            }    
            return i;
        }

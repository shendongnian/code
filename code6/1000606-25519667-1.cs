        static int errorCounter;
        static void Main(string[] args)
        {
            List<Item> lstItems = new List<Item>();
            foreach (var item in lstItems)
            {
                errorCounter = 0;
                bool succesful = CustomAction(item);
            }
        }
        static bool CustomAction(Item item)
        {
            try
            {
                //your custom actions with the item
            }
            catch (Exception ex)
            {
                if (errorCounter < 3)
                {
                    errorCounter++;
                    CustomAction(item);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

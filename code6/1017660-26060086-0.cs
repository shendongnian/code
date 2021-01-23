            List<item> ItemsList = new List<item>();
            item item1 = new item();
            item1.ID = "1";
            item1.keywords = new List<string>();
            item1.keywords.Add("Rabbit");
            item1.keywords.Add("Dog");
            item1.keywords.Add("Cat");
            ItemsList.Add(item1);
            item item2 = new item();
            item2.ID = "2";
            item2.keywords = new List<string>();
            item2.keywords.Add("Rabbit");
            item2.keywords.Add("Hedgehog");
            item2.keywords.Add("Dog");
            ItemsList.Add(item2);
            //this the list you want to check
            var values = new List<string> (); 
            values.Add("Dog");
            values.Add("Cat");
            var result = from x in ItemsList
                         where !(values.Except(x.keywords).Any())
                         select x;
            foreach (var item in result)
            {
              // Check the item.ID;
                
            }

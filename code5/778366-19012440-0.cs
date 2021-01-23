            var oldList = new List<string>();
            oldList.Add("bar one");
            oldList.Add("bar two");
            oldList.Add("bar three");
            oldList.Add("bar four");
            
            var newList = new List<string>();
            newList.Add("bar two");
            newList.Add("bar three");
            newList.Add("bar four");
            newList.Add("bar five");
            var itemsToRemove = oldList.Except(newList);    // should only contain "bar one"
            var itemsToAdd = newList.Except(oldList);    // should only contain "bar one"
            
            foreach (var item in itemsToRemove)
            {
                Console.WriteLine(item + " removed");
            }
            foreach (var item in itemsToAdd)
            {
                Console.WriteLine(item + " added");
            }

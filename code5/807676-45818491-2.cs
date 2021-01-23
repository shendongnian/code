      public void SelectListItemRandom(string ListID,UITestControl parent)
        {
           HtmlList listDir = new HtmlList(parent);
           listDir.SearchProperties[HtmlList.PropertyNames.Id] = ListID;
           listDir.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
           Console.WriteLine("List item Count: " + listDir.ItemCount);
           int selectedindex = random.Next(1, listDir.ItemCount);
           Console.WriteLine("Selected random index: " + selectedindex);
           listDir.SelectedIndices = new int[] { selectedindex };  
        }

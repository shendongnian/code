            var customListItems = new List<CustomListItem>();
            var customListItem1 = new CustomListItem() { name = "Item 1", date = DateTime.MinValue };
            var customListItem2 = new CustomListItem() { name = "Item 2", date = DateTime.MinValue };
            var customListItem3 = new CustomListItem() { name = "Item 3", date = DateTime.MinValue };
            customListItems.Add(customListItem1);
            customListItems.Add(customListItem2);
            customListItems.Add(customListItem3);
            var newCustomListItem = new CustomListItem() { name = "Item 4", date = DateTime.Now };
            customListItems[customListItems.FindIndex(x => x.name == "Item 2")] = newCustomListItem;

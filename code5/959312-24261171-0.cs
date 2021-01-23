        static void Main(string[] args)
        {
            // Create sample data
            List<string> items = new List<string>();
            items.Add("Modal                    000");
            items.Add(" Child1                  100");
            items.Add("  Child1                 110");
            items.Add(" Child2                  200");
            items.Add("  Child1                 210");
            items.Add("  Child2                 220");
            items.Add("   Child1                221");
            items.Add(" Child3                  300");
            // Initialize the collection object
            CustomDefinition customDefinition = new CustomDefinition();
            customDefinition.Children = new List<CustomControl>();
            
            // Keep reference to the previous item in the list
            CustomControl prevItem = null;
            for (int i = 0; i < items.Count; ++i)
            {
                // Find indentation level
                int currentIndent = items[i].TakeWhile(c => char.IsWhiteSpace(c)).Count();
                string[] itemIdPair = items[i].Split(' ').ToArray();
                // Create CustomControl from data
                CustomControl currentItem = new CustomControl();
                currentItem.Id = (itemIdPair[itemIdPair.Length -1]);
                currentItem.Name = itemIdPair[0];
                currentItem.IndentLevel = currentIndent;
                // Add CustomControl reference to the collection
                customDefinition.Children.Add(currentItem);
                // First item - main node
                if (prevItem == null)
                {
                    prevItem = currentItem;
                }
                // Siblings - get the same parent
                else if (currentItem.IndentLevel == prevItem.IndentLevel)
                {
                    CustomControl parent = customDefinition.Children.Where(item => item.Id == prevItem.Id).FirstOrDefault();
                    currentItem.ParentId = parent.Id;
                    if (parent.Children == null)
                        parent.Children = new List<CustomControl>();
                    parent.Children.Add(currentItem);
                }
                // Child
                else if (currentItem.IndentLevel > prevItem.IndentLevel)
                {
                    currentItem.ParentId = prevItem.Id;
                    if (prevItem.Children == null)
                        prevItem.Children = new List<CustomControl>();
                    prevItem.Children.Add(currentItem);
                }
                // Item's level is higher than the previous item - find how far does it go and
                // get the parent for the item
                else
                {
                    // parent's indentation will be one level higher than the current one
                    // try to find it
                    CustomControl parent = GoBackToLevel(customDefinition.Children, prevItem, currentIndent - 1);
                    currentItem.ParentId = parent.Id;
                    if (parent.Children == null)
                        parent.Children = new List<CustomControl>();
                    parent.Children.Add(currentItem);
                }
                // Replace the reference to the previous item.
                prevItem = currentItem;
            }
        }
        private static CustomControl GoBackToLevel(List<CustomControl> items, CustomControl start, int parentLevel)
        {
            CustomControl parent = items.Where(item => item.Id == start.ParentId).FirstOrDefault();
            if (parent.IndentLevel == parentLevel)
                return parent;
            else
                return GoBackToLevel(items, parent, parentLevel);
        }

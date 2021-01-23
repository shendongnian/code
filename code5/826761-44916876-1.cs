        public static bool SelectPropertyGridItemByName(this PropertyGrid propertyGrid, string propertyName)
        {
            MethodInfo getPropEntriesMethod = propertyGrid.GetType().GetMethod("GetPropEntries", BindingFlags.NonPublic | BindingFlags.Instance);
            Debug.Assert(getPropEntriesMethod != null, @"GetPropEntries by reflection is still valid in .NET 4.6.1 ");
            GridItemCollection gridItemCollection = (GridItemCollection)getPropEntriesMethod.Invoke(propertyGrid, null);
            GridItem gridItem = TraverseGridItems(gridItemCollection, propertyName);
            if (gridItem == null)
            {
                return false;
            }
            propertyGrid.SelectedGridItem = gridItem;
            return true;
        }
        private static GridItem TraverseGridItems(IEnumerable parentGridItemCollection, string propertyName)
        {
            foreach (GridItem gridItem in parentGridItemCollection)
            {
                if (gridItem.Label != null && gridItem.Label.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                {                   
                    return gridItem;
                }
                if (gridItem.GridItems == null)
                {
                    continue;
                }
                GridItem childGridItem = TraverseGridItems(gridItem.GridItems, propertyName);
                if (childGridItem != null)
                {
                    return childGridItem;
                }
            }
            return null;
        } 

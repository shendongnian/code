    public class GridItem
    {
        public class GridBase
        {
            internal GridBase() { }
            public void AddItem(GridItem item)
            {
                item.InformAddedToGrid();
            }
        }
        private void InformAddedToGrid()
        {
            Debug.Log("I've been added to the grid");
        }
    }
    public class Grid : GridItem.GridBase { }

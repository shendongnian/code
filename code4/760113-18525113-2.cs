    public class Grid
    {
        public void AddItem(GridItem item)
        {
            ((IGridInformer)item).InformAddedToGrid();
        }
    }
    public class GridItem : IGridInformer
    {
        void IGridInformer.InformAddedToGrid()
        {
            Debug.Log("I've been added to the grid");
        }
    }
    internal interface IGridInformer
    {
        void InformAddedToGrid();
    }

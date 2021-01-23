    public class GridDeleteButton : DataControlField, IDisposable
    {
        private ImageButton button;
        public event ImageClickEventHandler Click;
        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            button = new ImageButton
                     {
                         ImageUrl = "...",
                         CommandName = "Delete",
                         OnClientClick = @"return confirm('Are you sure?');"
                     };
            if (Click != null) button.Click += Click;
            cell.Controls.Add(button);
        }
        protected override DataControlField CreateField()
        {
        }
        public void Dispose()
        {
            if (button != null) button.Dispose();
        }
    }

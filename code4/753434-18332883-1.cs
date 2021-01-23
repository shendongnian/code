    // instances of this type user should edit in data grid
    public class Item : IEditableObject
    {
        // the item identifier
        public int Id { get; set; }
        // some data-bound properties
        #region IEditableObject Members
        public void BeginEdit()
        {            
        }
        public void CancelEdit()
        {
        }
        public void EndEdit()
        {
            // new items has identifier, set to 0
            if (Id == 0)
            {
                // post changes here
            }
        }
        #endregion
    }

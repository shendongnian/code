    // instances of this type user should edit in data grid
    public class Item : IEditableObject
    {
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
            // post changes here
        }
        #endregion
    }

    class EditablePurchase : Purchase, IEditableObject
    {
        public Action<Purchase> Edited { get; set; }
        private int numEdits;
        public void BeginEdit()
        {
            numEdits++;
        }
        public void CancelEdit()
        {
            numEdits--;
        }
        public void EndEdit()
        {
            if (--numEdits == 0)
            {
                if (Edited != null)
                    Edited(this);
            }
        }
    }

    public class InvoiceItemsDTO
    {
        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set 
            {
                _selected = value;
    
                //This is where your code should be.
                if (value)
                   ProductQuantity++;
                else
                   ProductQuantity--;
            }
        }
    }

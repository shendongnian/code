    public class CustomerTypeCell : DataGridViewTextBoxCell
    {
        public CustomerTypeCell() 
            : base() 
        { }
    
        public override Type ValueType
        {
            get
            {
                return typeof(CustomerType);
            }
        }
        
        public override Type EditType
        {
            get
            {                 
                return typeof(CustomEditingControl);
            }
        }       
    }

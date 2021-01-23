    public partial class frmCustomerList
    {
        private MyTypedDataSet ds = new MyTypedDataSet();
    
        protected override void Dispose(bool disposing)
        {
            ds.Dispose();
    
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    
        //The rest of your frmCustomerList.cs file.
    }

	public partial class frmCustomersRecord : Form 
	{
	 public frmCustomersRecord()
    	{
       		//blank contructor (Instance of an class)
    	}
	    frmCustomerDetails cd;
	    public frmCustomersRecord(frmCustomerDetails parentForm) : this()
    	{
        	this.cd = parentForm; 
    	}	 
    	//call the methods using child form object
	}

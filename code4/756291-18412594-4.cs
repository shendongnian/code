    public abstract class DataObject<T> where T : DataObject<T>{
    	 public virtual DataObject<T> Save(){
    	 	return this;
    	 }
    }
    
    public abstract class InvoiceObject<T> : DataObject<T> where T : DataObject<T> {
        // base data for the class goes here	
    }
    
    public class Invoice : InvoiceObject<Invoice> {
        
    }

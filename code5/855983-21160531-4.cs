    public partial class Customer
    {
    public Customer()
    {
        this.Contacts = new ObservableListSource<Contact>();
    }
    public int CustomerId { get; set; }
    public int CustomerCustomId { get; set; }
    public string CustomerName { get; set; }
    protected ObservableListSource<Contact> _Contacts;
    public virtual ObservableListSource<Contact> Contacts 
    { 
      get{            
        if( _Contacts==null) _Contacts= new ObservableListSource<Customer>();            
          return _Contacts;
          } 
        set{
             _Contacts=value;
           } 
         }
    } 

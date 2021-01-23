    class Customer {
      public Customer(){
        Products = new BindingList<Product>();
        Products.ListChanged += (s,e) => {
           if(e.ListChangedType == ListChangedType.ItemAdded){
             Products[e.NewIndex].CustomersWhoBoughtThis.Add(this);
           }
        };
      }
      public BindingList<Product> Products { get; set; }
    }
    

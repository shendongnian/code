    class main_menu
    {
       Customer[] cust = new Customer[100];
       // some other data members
    
       public void new_customer()
       {
        cust[0] = new Customer();
          // when you want to use it later on, do this validation.
        if (cust[0] != null)
        {      
            cust[0].add_customer();
        }
       }
    }

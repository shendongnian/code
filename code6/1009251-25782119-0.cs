    void method() {
         MyObject activator = new ...
         AnotherObject db_connection = new ...
         Proxy p = new ...
         try{
             // some other variables 
             if(..)
                // Do some post calculations
             if(..)
                // Do some post calculations
             if(..)
                // Do some post calculations
        }
        finally{
            // Deactivate activator, close db connection, call a webservice to confirm user exited
        }
          return;
    }

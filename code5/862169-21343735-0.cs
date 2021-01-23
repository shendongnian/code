    class Address
    {
      private string _state;  // the _state field 
      public string State// the State property
      {
        get
         {
            return _state;
         }
      }
      private void SetState()
      {
          if(GetStateByZipCode(string ZipOrPostalCode, string ST))
            {
               _state = "ST";
            }
          else
            {
                _state = "Not ST";
            }
      }
    } 

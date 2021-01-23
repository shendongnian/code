      protected void ValidatoreTipiDato_ServerValidate(object source, ServerValidateEventArgs args)
      {
         try 
         {
            // Test whether the value entered into the text box is even.
            int i = int.Parse(args.Value);
            args.IsValid = ((i%2) == 0);
         }
         catch(Exception ex)
         {
            args.IsValid = false;
         }
      }

    public void ProcessApplicantAddress(ApplicantAddress line)
    {
        if (line == null)
        {
            eventListener.HandleEvent(Severity.Informational, line.GetType().Name, "a message");
            throw new ArgumentNullException("line");
         }
         Customer customer = GetCustomer(line.TaxId);
         if (customer == null)
         {
             eventListener.HandleEvent(Severity.Informational, line.GetType().Name, "a message");
             throw new InvalidOperationException("a message");
         }
         Address address = new Address();
         if (address == null)
         {
            eventListener.HandleEvent(Severity.Informational, line.GetType().Name, "a message");
            throw new InvalidOperationException("a message");
         }
         address.AddressLine1 = line.StreetAddress;
         address.City = line.City;
         address.State = State.TryFindById<State>(line.State);
         address.Zip = ZipPlusFour(line.Zip, line.ZipCodePlusFour);
    }

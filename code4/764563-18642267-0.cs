    public void ProcessApplicantAddress(ApplicantAddress line)
    {
            
        var customer = loan.GetCustomerByTaxId(new TaxId(line.TaxId));
        if (customer == null)
        {
            eventListener.HandleEvent(Severity.Informational, "ApplicantAddress", String.Format(""Could not find the customer corresponding to the taxId '{0}' Applicant address will not be imported."", line.TaxId));
        }
        else
        {
            var address = new Address();
            address.AddressLine1 = line.StreetAddress;
            address.City = line.City;
            address.State = State.TryFindById<State>(line.State);
            address.Zip = ZipPlusFour(line.Zip, line.ZipCodePlusFour);
            //do whatever else you need to do with address here.
        }
    }

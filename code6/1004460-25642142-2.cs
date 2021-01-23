    public int AddVendor(string companyname, string addressOne, string addressTwo, string city, string state, string country, string phone, string email, WorkDays workingDays)
    {
        var vendor = new Vendor()
        {
            // skipped for brevity
            WorkingDays = workingDays
        };
        _unitOfWork.VendorRepository.Insert(vendor);
        _unitOfWork.VendorRepository.Save();
        
        return vendor.Id;
    }
        

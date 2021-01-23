    public int AddVendor(string companyname, string addressOne, string addressTwo, string city, string state, string country, string phone, string email, int workingDays)
        {
            var vendor = new Vendor()
            {
                // skipped for brevity
                WorkingDays = (WorkDays)workingDays
            };
            _unitOfWork.VendorRepository.Insert(vendor);
            _unitOfWork.VendorRepository.Save();
    
            return vendor.Id;
        }
    [HttpPost]
        public ActionResult Create(VendorViewModel model)
        {
            //... skipped for brevity
            var vendor = _vendorService.AddVendor(model.CompanyName, model.AddressLineOne, model.AddressLineTwo, model.City, model.State, model.Country,model.OpeningTime,model.ClosingTime, model.Phone, model.Email, (int)model.WorkingDays);
            //... skipped for brevity
    
        }

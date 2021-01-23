    public List<Country> getCountryList()
            {
                using (QRMG_VendorPortalDataContext _context = new QRMG_VendorPortalDataContext())
                {
                    return (from c in _context.Countries
                            where c.IsDeleted == false
                            select c).ToList();
                }
            }

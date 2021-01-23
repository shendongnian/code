    List<Model_Bulk> q = (from a in db.Advertises join c in db.Companies on a.AdvertiseCompanyID equals c.CompanyID
                                  where a.AdvertiseActive == true && a.AdvertiseExpireDate.HasValue && a.AdvertiseExpireDate.Value > DateTime.Now && (a.AdvertiseObjectType == 1 || a.AdvertiseObjectType == 2)
                                  select c)
                     .GroupBy(a => a.CompanyID)
                     .Select(a => new Model_Bulk
                     {
                         CompanyEmail = a.First().CompanyContactInfo.Email,
                         CompanyID = a.Key, //Note this line, it's can be happened becouse of GroupBy()
                         CompanyName = a.First().CompanyName,
                         Mobile = a.First().CompanyContactInfo.Cell,
                         UserEmail = a.First().User1.Email,
                         categories = a.First().ComapnyCategories
                     }).ToList();

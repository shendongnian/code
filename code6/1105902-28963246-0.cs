    (from a in db.Advertises
                              join c in db.Companies on a.AdvertiseCompanyID equals c.CompanyID
                              where a.AdvertiseActive == true && a.AdvertiseExpireDate.HasValue && a.AdvertiseExpireDate.Value > DateTime.Now && (a.AdvertiseObjectType == 1 || a.AdvertiseObjectType == 2)
                              select c)
                 .GroupBy(a => a.CompanyID)
                 .Select(g => g.First())
                 .Select(a => new Model_Bulk
                 {
                     CompanyEmail = a.CompanyContactInfo.Email,
                     CompanyID = a.CompanyID,
                     CompanyName = a.CompanyName,
                     Mobile = a.CompanyContactInfo.Cell,
                     UserEmail = a.User1.Email,
                     categories = a.ComapnyCategories
                 }).ToList();

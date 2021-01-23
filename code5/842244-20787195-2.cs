    var j = (from a in linqedit.Kharids
             select new {
                 a.ID,
                 نام_کالا = a.KalaName.Name,
                 مقدار = a.mount.Value,
                 واحد_خرید = a.VehedeKharid.Name,
                 قیمت = a.Price,
                 نوع_خرید = a.KindOfKharid.Name,
                 نام_خریدار = a.NameKHaridar,
                 تاریخ = a.Date.Date.Year + "/" + a.Date.Date.Month + "/" + a.Date.Date.Day
             }).ToList();

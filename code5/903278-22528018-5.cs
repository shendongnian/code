    var totalRecords = users.Count(); // total number of users
    return Json(new {
        total = (totalRecords + rows - 1) / rows,
        page,
        records = totalRecords,
        rows = (from item in pageOfUsers
                select new[] {
                    user.Id.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    user.Name,
                    user.Email,
                    user.Password,
                    user.Description,
                    user.Phone,
                    user.Address,
                    user.Date == null ? "": ((DateTime) user.Date).ToString("o")
                }).ToList()
    }, JsonRequestBehavior.AllowGet);

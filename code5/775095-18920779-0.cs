    ViewBag.VendorID = new SelectList(db.Vendors.Select(m => new SelectListItem
        {
            Value = m.ID,
            Text = string.Format("{0} {1}", m.FirstName, m.LastName)
        }, "Value", "Text", property.VendorID);

    var query = from inq in Inquiries
            join sp in SalesPersons on inq.AssignedToID equals (int?)sp.SalesPersonID
            into inquirySalesJoin
            from subsp in inquirySalesJoin.DefaultIfEmpty()
            where (!inq.Deleted)
            select new 
            {
            InquiryID = subsp.InquiryID,
            NameFirst = subsp.NameFirst,
            Salutation = subsp.SalutationID,
            NameLast = subsp.NameLast,   
            AssignedToID = subsp.AssignedToID,
            AssignedToDescription = (subsp.AssignedToID == null ? "Not Assigned" : ((subsp.NameFirst    == null ? "" : subsp.NameFirst) + " " + (subsp.NameLast == null ? "" : subsp.NameLast))),
            InquiryStatus = subsp.InquiryStatus
            }

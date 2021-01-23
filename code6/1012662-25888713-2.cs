     public IList<OHList> GetValues_Admin(Guid companyID)
    {
	IList<OHList> tblObj = null;
	try
	{
		
		tblObj = (from OH in _entities.tbl_OrderHeader
				  join DO in _entities.tbl_DeliveryOrder on OH.ID equals DO.OrderHeaderID into t1
				  from t11 in t1.DefaultIfEmpty()
				  join IH in _entities.tbl_InvoiceHeader on OH.ID equals IH.OrderHeaderID into t2
				  from t22 in t2.DefaultIfEmpty()
				  join UA in _entities.tbl_UserAccount on OH.CreatedUserID equals UA.ID                          
				  join UP in _entities.tbl_UserProfile on UA.UserProfileID equals UP.ID
				  where (OH.Active == true) && (UP.CompanyID == companyID)
				  orderby OH.OrderNo descending
				  select new OHList 
				  {
					  OrderNo = OH.OrderNo,
					  PONo = OH.PONo,
					  CostCenter = OH.CostCenter,
					  ExpectedDeliveryDate = OH.ExpectedDeliveryDate,
					  DeliveryDate = t11.DeliveryDate,
					  PrimaryContactPerson = OH.PrimaryContactPerson ?? "",
					  AlternateContactPerson = OH.AlternateContactPerson ?? "",
					  PrimaryContactNo = OH.AlternateContactNo ?? "",
					  AlternateContactNo = OH.AlternateContactNo ?? "",
					  CreatedDate = OH.CreatedDate,
					  OrderDate = OH.CreatedDate,
					  WaybillNo = OH.WaybillNo,
					  DeliveryStatus = t11.DeliveryStatus,
					  Email = OH.Email ?? "",
					  Address = OH.Address ?? "",
					  PostalCode = OH.PostalCode ?? "",
					  City = OH.City ?? "",
					  Branch = OH.Branch,
					  DONo = t11.DONo,
					  InvoiceNo = t22.InvoiceNo ?? "",
					  IsPaid = (t22.IsPaid == true) ? true : (bool?)null
				  }).ToList();
	}
	catch (Exception ex)
	{
		base.Exception(ex);
	}
    	return tblObj;
    }

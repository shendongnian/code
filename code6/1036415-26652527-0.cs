	public static IQueryable<Tender> AddPublicCriteria(this IQueryable<Tender> tenderQuery) {
		// I've omitted your call to DateTime.Now.GetEasternStandardDateTime()
		// since you do not use it.
		return tenderQuery
			.Where(tender => tender.EndDate > DateTime.Now &&
							 tender.IsClosed == false && 
							 tender.IsCancel == false && 
							 tender.PrivacyLevelId == 1
			 );
	}
	var query = Tenders;                       // Original table or data-set
	query = query.AddPublicCriteria();         // Add criteria
	var results = query.ToList();              // Run query and put the results in a list

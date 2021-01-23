    var AgreementNew = new Agreement();  // create a new instance
    AgreementNew.SomeProperty = AgreementOld.SomeProperty; // assign property from old to new
    AgreementNew.AgreementID = AgreementIDNew; // new proerties here
    AgreementNew.StatusChangeDate = DateTime.Now;
    AgreementNew.CreationDate = DateTime.Now;
    AgreementNew.AccountID = ids.accountID;
    AgreementNew.CreatedByID = ids.userID;
    TDC.tblAgreements.InsertOnSubmit(AgreementNew);

    if (model.NewClub_Id > 0)
    {
        httpStatus = HttpStatusCode.OK;
        NewClub newClub = db.NewClubs.Single(nc => nc.Id == model.NewClub_Id);
        newClub.ClubCounselorMasterCustomerId = model.ClubCounselorMasterCustomerId;
        newClub.ClubCounselorContact = model.ClubCounselorContact;
        newClub.ClubCounselorEmail = model.ClubCounselorEmail;
        newClub.ClubCounselorPhone = model.ClubCounselorPhone;
        newClub.DateUpdated = DateTime.Now;
        try
        {
            var dbResult = db.SaveChanges() > 0;
        }
        catch (SqlException ex)
        { 
           [...]
        }
    }

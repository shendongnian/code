    var committeeMemberQuery =
               db.Committee_Member.*WHERE*
               (x => 
                  x.Customer_Number == activity.Contact.Number
                     && x.Position_Start_Date.Value.Year == activity.EndDate
                     && x.Committee_Id == activity.Committee.Id && x.Cancelled != 1
               );
    
    var committeeMember = committeeMemberQuery.FirstOrDefault();

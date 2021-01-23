            var res = from tbl1 in dbContext.MaterialApplicants
                      join tbl2 in dbContext.MaterialRequests on tbl1.ApplicantID equals tbl2.Applicant
                      where tbl2.RCD_ID == reqNo
                      select new MaterialItem
                      {
                          Crusher = tbl2.Crusher,
                          ApplicantID = tbl2.Applicant,
                          Comments = tbl2.Comments,
                          ReqDate = tbl2.ReqDate,
                          Operator = tbl2.Operator,
                          Title = tbl1.Title,
                          Applicant = tbl1.Applicant,
                          Address = tbl1.Address,
                          Nationality = tbl1.Nationality,
                          HouseNo = tbl1.HouseNo,
                          MobileNo = tbl1.MobileNo,
                      };

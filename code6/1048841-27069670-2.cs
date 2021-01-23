    var lRowsMarketForDeletion = (from lSubjectLocal in lDataSet.Tables[0].AsEnumerable()
                                          join lSubjectLocalbands in lDataSet.Tables[1].AsEnumerable() on lSubjectLocal.pkSummarySubjectLocalID equals lSubjectLocalbands.pkSummarySubjectLocalID_2 into lJoinedGroup
                                          from lJoinedRow in lJoinedGroup.DefaultIfEmpty(new RosterSummaryData_Subject_Local { pkSummarySubjectLocalID = 0 })
                                          where lJoinedRow.pkSummarySubjectLocalID == 0
                                          select new RosterSummaryData_Subject_Local
                                          {
                                              pkSummarySubjectLocalID = lRosterSummaryBand.Field<System.Int64>("pkSummarySubjectLocalID")
                                          }).ToList();
    customerContext.RosterSummaryData_Subject_Local.RemoveRange(lRowsMarketForDeletion);

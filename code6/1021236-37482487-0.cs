     var query = from lc in db1.LotteryCardMaster
                 from om in db2.OwnerMaster
                 where lc.IsActive == 1
                 select new
                            {
                                lc.CashCardID,
                                lc.CashCardNO,
                                om.PersonnelName,
                                lc.Status
                               
                            };
    AB.LottryList = new List<LotteryCardMaster>();
                foreach (var result in query)
                {
                    AB.LottryList.Add(new LotteryCardMaster()
                    {
                        CashCardID = result.CashCardID,
                        CashCardNO = result.CashCardNO,
                        PersonnelName =result.PersonnelName,
                        Status = result.Status
                       
                    });
                }

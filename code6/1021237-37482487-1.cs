    var query = from lc in db1.LotteryCardMaster
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
                        PersonnelName =db2.OwnerMaster.FirstOrDefault(x=>x.OwnerID== result.OwnerID).OwnerName,
                        Status = result.Status
                       
                    });
                }

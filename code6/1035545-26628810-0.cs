    List<CompressedLogResponse> listOne = new List<CompressedLogResponse>();
    //....
    //fill the listOne
    //....
    List<CompressedLogResponse> listWithoutListLog = (from item in listOne
                                          select new CompressedLogResponse(
                                                LoggerType = item.LoggerType,
                                                NumberOfRegisters = item.NumberOfRegisters ,
                                                NewLogId = item.NewLogId ,
                                                LoggerAnnounceTime = item.LoggerAnnounceTime ,
                                                Log= null)).ToList();
                                           

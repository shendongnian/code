    result =
        firstIdeaRepository.FindBy(
            i => i.FirstIdeaState == FirstIdeaState && i.Date >= start && i.Date <= end)
                .AsEnumerable()
                .Select(j => new RptListOfCompanyBasedOnFirstIdeaState()
                {
                    Name =
                        companyRepository.FindBy(i => i.UserId == j.UserId)
                            .FirstOrDefault()
                    DateOfMeeting =
                        callenderRepository.ConvertToPersianToShow(
                            meetingReposiotry.FindBy(s => s.FirstIdeaId == j.Id)
                                // project a new sequence first, before calling `FirstOrDefault`:
                                .Select(s => s.Date)
                                .FirstOrDefault(),
                    DateOfExit =
                        j.DateOfExit.HasValue ? 
                            callenderRepository.ConvertToPersianToShow(j.DateOfExit.Value) :
                            null,                       
                       ReasonOfExit = j.ReasonOfExit,
                   }).ToList();

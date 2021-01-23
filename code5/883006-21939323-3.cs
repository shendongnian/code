    var queryList = _emailSendResultsRepository.GetTable()
        .Where(e => e.EmailId == email.Id)
        .Where(e.SendDate >= startDate)
        .ToList();
        if (queryList.Any())
        {
            ....
            queryList.Count()....
            ....
        }

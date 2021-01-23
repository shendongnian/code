    List<UserAssitanceView> AllAssitance = objFirstIdeaAssistanceRepository.GetAll().Select(i => new UserAssitanceView()
        {
            assitanceId = i.Assistance.Id.ToString(),
            assitanceInternalTell = i.Assistance.AssistanceTell,
            assitanceName = i.Assistance.AssistanceName,
        })
       .ToList();

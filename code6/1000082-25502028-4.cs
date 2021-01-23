    foreach (var item in AllAssitance)
    {
        item.experteName = objAssistanceRepository.ReturnExpertOfAssitance(i.AssistanceId).Name;
        item.expertFamily = objAssistanceRepository.ReturnExpertOfAssitance(i.AssistanceId).Family;
        item.ExperteMobile = objAssistanceRepository.ReturnExpertOfAssitance(i.AssistanceId).Mobile;
    }

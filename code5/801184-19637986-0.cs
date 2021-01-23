    var linqQuery = 
        from nn in grantsReceivedDetailList
        where (nn.ArrearAuditID == Convert.ToInt32(AdminBasePage.ArrearAuditId))
        select new {
           nn.GrantsReceivedID,
           nn.PayeeMPINumber,
           Firstname = participantRepository.GetParticipantDetailsbyMemberParticipantIndex(Convert.ToInt32(nn.PayeeMPINumber)).FirstName + " " +
                       participantRepository.GetParticipantDetailsbyMemberParticipantIndex(Convert.ToInt32(nn.PayeeMPINumber)).LastName,
           nn.IVANumber,
           GrantMonthID = nn.GrantMonthID.ToString().Substring(4, 2) + "/" +          
                          nn.GrantMonthID.ToString().Substring(0, 4),
           nn.GrantAmount,
           nn.Comments,
           GrantMonthIdOriginal = nn.GrantMonthID // this field
        };

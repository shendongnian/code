      var result = (from spa in sap2PartnerAllowance
                          join spt in sap2Partners on spa.PartnerNumber equals spt.PartnerNumber
                          join al in allowance on spa.AllowanceID equals al.AllowanceMasterId
                          join cr in currency on spa.Currency.CurrencyId equals cr.CurrencyId
                          join fr in frequency on spa.Frequency.FrequencyID equals fr.FrequencyID
                          select new 
                          {
                              PartnerNumber = spa.PartnerNumber,
                              FirstName = spt.FirstName,
                              LastName = spt.LastName,
                              AllowanceName = al.AllowanceName,
                              StartDate =  spa.StartDate,
                              EndDate = spa.EndDate,
                              Amount = spa.Amount,
                              Frequency = fr.FrequencyDescription,
                              Currency = cr.CurrencyDesciption,
                              Note = spa.Note
                          }).ToList();
            var result2 =result.Select(spa=>new DataEntityUI
                          {
                              PartnerNumber = spa.PartnerNumber,
                              FirstName = spa.FirstName,
                              LastName = spa.LastName,
                              AllowanceName = spa.AllowanceName,
                              StartDate = String.Format(CurrentUserPreferences.DateFormat, spa.StartDate),
                              EndDate = String.Format(CurrentUserPreferences.DateFormat, spa.EndDate),
                              Amount = spa.Amount,
                              Frequency = spa.FrequencyDescription,
                              Currency = spa.CurrencyDesciption,
                              Note = spa.Note
                          }).ToList();

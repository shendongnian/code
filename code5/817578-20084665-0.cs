       NewPartHistory = new CdaService.PartHistory();
       NewPartHistory.EnteredBy = User.Current.UID;
       NewPartHistory.Entry = historyText;
       NewPartHistory.EntryDate = DateTime.UtcNow;
       NewPartHistory.PartId = ThisPart.Id;

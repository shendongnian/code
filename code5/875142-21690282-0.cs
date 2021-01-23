    Dictionary<dynamic, string> _errors = new Dictionary<dynamic, string>();
    
    if(from c in _errors where(key.zip.Id != existingKey.Id &&
                    key.zip.ChannelCode != existingKey.ChannelCode &&
                    key.zip.DrmTerrDesc != existingKey.DrmTerrDesc &&
                    key.zip.IndDistrnId != existingKey.IndDistrnId &&
                    key.zip.StateCode != existingKey.StateCode &&
                    key.zip.ZipCode != existingKey.ZipCode &&
                    key.zip.EndDate.Date != existingKey.EndDate.Date &&
                    key.zip.EffectiveDate.Date != existingKey.EffectiveDate.Date &&
                    key.zip.ErrorCodes != existingKey.ErrorCodes &&
                    key.zip.Status != existingKey.Status) select c.key).FirstOrDefault()==null)
    {
     errorList.Add(zip, string.Empty);
    
    }

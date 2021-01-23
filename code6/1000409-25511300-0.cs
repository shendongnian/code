    foreach(string prop in propertiesToCheck)
            {
                 if(!job.TaxForms.TrueForAll(t => t.ARecord.GetType().GetProperty(prop).GetValue(t.ARecord, null).ToString() == job.TaxForms[0].ARecord.GetType().GetProperty(prop).GetValue(job.TaxForms[0].ARecord, null).ToString()))
                 {
                     conflictingPropertiesList.Add(prop);
                 }
            }

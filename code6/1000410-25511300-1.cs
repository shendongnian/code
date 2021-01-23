    foreach(string prop in propertiesToCheck)
            {
                 if(!job.TaxForms.TrueForAll(t => t.ARecord.GetType().GetProperty(prop).GetValue(t.ARecord, null).ToString().Equals(job.TaxForms[0].ARecord.GetType().GetProperty(prop).GetValue(job.TaxForms[0].ARecord, null).ToString())))
                 {
                     conflictingPropertiesList.Add(prop);
                 }
            }

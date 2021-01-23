    param.Patient.PatientGroups
        .Select( g => String.Join( "-"
                                 , (new string[] { g.Wing, g.Floor, g.Room, g.Bed, g.Table })
                                   .Where(x => !string.IsNullOrEmpty(x))
                                   .ToArray()
                                 )
               ).FirstOrDefault()

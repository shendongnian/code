    var groupedInfo = from patient in IcdPatient.GetIcdPatientList()
                      group patient by patient.PatientId
                        into patients
                        select new { Id = patients.Key,
                                     Conditions = patients.Select(patient => patient.ConditionCode) };
    var resultAlt = from g in groupedInfo
                    where g.Conditions.All(condition => filteringList.Contains(condition))
                    select g.Id;

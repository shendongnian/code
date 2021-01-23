    var response = ApiDB.Persons.Include(y => y.JobTitle).Include(b => b.Discipline).Include(b => b.Team).Include(b => b.Site).OrderBy(d => d.DisplayName).ToArray();
            foreach (var person in response)
            {
                person.JobTitle = new JobTitle()
                {
                    JobTitle_ID = person.JobTitle.JobTitle_ID,
                    JobTitleName = person.JobTitle.JobTitleName,
                    PatientInteraction = person.JobTitle.PatientInteraction,
                    Active = person.JobTitle.Active,
                    IsClinical = person.JobTitle.IsClinical
                };
            }

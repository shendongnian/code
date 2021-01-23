                        select new
                        {
                           m.MedicalID,
                           m.medicalName,
                           m.City
                        };
           EntityDataSource eds = new EntityDataSource();
           eds.ConnectionString = "name=EntitiesMedical";
           eds.DefaultContainerName = "EntitiesMedical";
           eds.EntitySetName = "Medicals";

    public FileContentResult GetImage(string patientId)
        {
            using (var ctx = new MedikEntities())
            {
                var patient = ctx.Patients.FirstOrDefault(p => p.PatientId == patientId);
                return patient != null ? File(patient.PatientPicture, patient.ImageMimeType) : null;
            }
        }

        public ServiceResponse<Patient> Save(Patient patient, string userName)
        {
            Func<Patient> func = delegate
            {
                Authorize(patient, userName);
                Validate(patient, new PatientValidator());
                using (var context = _contextFactory())
                {
                    return context.Save(patient, userName);
                }
            };
            return this.Execute(func);
        }

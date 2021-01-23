    public EmployeeFormatted(Employee em)
            {
                var emProps = em.GetType().GetProperties();
                foreach (var prop in emProps)
                {
                    this.GetType().GetProperty(prop.Name).SetValue(this,prop.GetValue(em));
                }
                this.FullName = FomratName(em.FirstName, em.LastName);
            }

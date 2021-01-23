    public List<Entity.Student> SearchStudent(string Name, int Age, string EmailAddress, string CountryName)
        {
            IQueryable<Entity.Student> lstStudents = this.GetAllStudent();
            if (!string.IsNullOrEmpty(Name))
            {
                lstStudents = lstStudents.Where(node => node.FirstName.Equals(Name) || node.LastName.Equals(Name));
            }
            if (Age > 0)
            {
                lstStudents = lstStudents.Where(node => node.Age == Age);
            }
            if (!string.IsNullOrEmpty(EmailAddress))
            {
                lstStudents = lstStudents.Where(node => node.Email.Equals(EmailAddress));
            }
            if (!string.IsNullOrEmpty(CountryName))
            {
                lstStudents = lstStudents.Where(node => node.Country .Equals(CountryName));
            }
            return lstStudents.ToList<Entity.Student>();
        }

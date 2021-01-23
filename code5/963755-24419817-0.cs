        [HttpGet]
        public IQueryable<Person> PersonsFlattened()
        {
            //return _contextProvider.QueryAll<Person>();
            var contacts = from person in _contextProvider.QueryAll<Person>()
                           join companyPerson in CompanyPersons() on person.Id equals companyPerson.PersonId into companyPersonGroups
                           from companyPerson in companyPersonGroups.DefaultIfEmpty()
                           select new Person()
                           {
                               FirstName = person.FirstName,
                               LastName = person.LastName
                               
                           };
            return contacts;
        }

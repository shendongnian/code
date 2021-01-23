        /// <summary>
        ///     fill automatically person data
        /// </summary>
        /// <param name="identification">search for this identification</param>
        /// <param name="cdmIdentification">this type of identification is search for</param>
        /// <returns>found person information</returns>
        [HttpPost]
        [Authorize(Policy = "RequireAuthenticatedRole")]
        public async Task<PersonEditViewModel> AutoFillPerson(string identification, PersonRepository.CDMIdentification cdmIdentification)        
        {
            // get person entity from database
            var task = new PersonRepository().GetPersonFromCdm(identification, cdmIdentification);
            // put it in a person viewmodel.
            return await task.ContinueWith((p) => new PersonEditViewModel() { Person = p.Result } ); 
        }

        [Route("api/Student/names")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "student1", "student2" };
        }

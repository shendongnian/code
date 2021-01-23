        [Route("search")]
        [HttpGet]
        public string search(string systemId = "", string patientId = "")
        {
            return patientId;
        }

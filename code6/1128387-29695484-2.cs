    [ActionName("SelectEmployees")]
    [HttpGet]
        public HttpResponseMessage SelectEmployees(Empdet empdet)
        {
            Collection<Empdet> Empdets =new Collection<Empdet>( db.Empdets.ToList());
            return Request.CreateResponse(HttpStatusCode.OK, Empdets);
        }

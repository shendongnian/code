        [HttpGet]
        [TransactionFilter]
        [Route("api/GetLatLong")]
        public HttpResponseMessage GetLatLong(string zip5)
        {
            if (zip5.Length != 5)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Zip Code Length Not Equal to 5");
            var zip = _zipCodeService.GetByZip5(zip5);
            if (zip == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find Zip Code in Database");
            var latlong = new
            {
                Latitude = zip.Latitude,
                Longitude = zip.Longitude
            };
            return Request.CreateResponse(HttpStatusCode.OK, latlong);
        }

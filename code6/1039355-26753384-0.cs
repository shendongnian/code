        [ActionName("Premise")]
        public IHttpActionResult GetPremise(string id)
        {
            id = id.Replace(" ", String.Empty).ToUpper();
            List<Premise> premises = _service.GetPremisesForPostcode(id);
            return Ok(premises);
        }
        [ActionName("Building")]
        public IHttpActionResult GetBuilding(string id)
        {
            double premise = Convert.ToDouble(id);
            Building building = _service.GetBuildingsForPremise(premise);
            return Ok(building);
        }

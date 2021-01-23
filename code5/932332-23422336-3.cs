        [HttpGet]
        [Route("api/Products/SpecificFuelTicket/{value}")]
        public string GetSpecificFuelTicket(int value)
        {
            try
            {
                return "Your ticket is " + value.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

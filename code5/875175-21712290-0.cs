        [HttpPost]
        public ActionResult Create(Address address)
        {
            //Loop through the request.forms
            var Addesslist = new List<Address>();
            for (int i = 1; i <= Request.Form.Count; i++)
            {
                var street = Request.Form["street_0" + i + ""];
                var city = Request.Form["city_0" + i + ""];
                var postalCode = Request.Form["postalCode_0" + i + ""];
                var province = Request.Form["province_0" + i + ""];
                var personID = 1;
                if (street != null && city != null && postalCode != null && province != null)
                {
                    try
                    {
                        context.Addresses.Add(new Address
                        {
                            Street = street,
                            City = city,
                            Province = province,
                            PostalCode = postalCode,
                            PersonID = personID
                        });
                        context.SaveChanges();
                    }
                    catch (Exception exc)
                    {
                        
                    }
                }
                else
                {
                    break;
                }
            }
            return RedirectToAction("Index");
        } 

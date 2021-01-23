     [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var data = new ModelObj();
            data.Str = (string)collection.GetValue("Str").ConvertTo(typeof(string));
            var personsString = (string)collection.GetValue("Persons").ConvertTo(typeof(string));
            using (var textReader = new StringReader(personsString))
            {
                using (var reader = new JsonTextReader(textReader))
                {
                    data.Persons = new JsonSerializer().Deserialize(reader, typeof(List<Person>)) as List<Person>; 
                }
            }
            
            return View(data);
        }

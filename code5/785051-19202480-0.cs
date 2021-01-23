      [HttpPost]
        [ActionName("Event")]
        public String AddSurvey()
        {
            // ... logic to modify or create data item
            string body;
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
                reader.Close();
            }
            return body;
        }

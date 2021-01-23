    // POST api/Categories
        public HttpResponseMessage PostCategories(Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categories);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, categories);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = categories.CategoryId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

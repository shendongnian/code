    // POST api/contactgroups/all
        [System.Web.Http.ActionName("All")]
        public IEnumerable<ContactsGroup> All()
        {
            return _biz.GetAllContactsGroup();
        }
        // POST api/contactgroups/find/5
        [System.Web.Http.ActionName("Find")]
        public ContactsGroup FindById(int id)
        {
            return _biz.GetContactGroup(id);
        }
        // POST api/contactgroups/create
        [System.Web.Http.ActionName("Create")]
        public HttpResponseMessage CreateContactGroup(ContactsGroup item)
        {
            item.UserId = HttpContext.Current.User.Identity.GetUserId();
            item.DateAdded = DateTime.Now;
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, item);
            if (!_biz.CreateContactGroup(item)) return Request.CreateResponse(HttpStatusCode.NotFound, item);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
            response.Headers.Location = new Uri(Request.RequestUri + item.Id.ToString());
            return response;
        }

    public HttpResponseMessage Put(CustomerPutModel data)
    {
        if (ModelState.IsValid)
        {
            var myID = userService.GetIDByUserName(HttpContext.Current.User.Identity.Name);
            if (myID != data.ID) 
            {
                ... wrong id, e.g. throw an exception or return a View indicating the error.
            }
            var c = customerService.GetByID(data.ID);
            if (c != null)
            {
                c = ModelMapper.Map<CustomerPutModel, Customer>(data, c);
                customerService.Update(c);
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }
        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
    }

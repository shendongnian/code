    var response = Request.CreateResponse(HttpStatusCode.Notfound);
    return response
    // GET api/employees/12345
    public HttpResponseMessage Get(int id)
    {
        HttpResponseMessage response = null;
        var employee = list.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            response = new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        else
        {
            response = Request.CreateResponse(HttpStatusCode.OK, employee);
        }
        return response;
    }

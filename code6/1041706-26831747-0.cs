    public HttpResponseMessage Post()
    {
             HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
             response.Content =
                 new StringContent("{\"openTimes\":{\"1\":\"09:00\", \"2\":\"09:15\", \"3\":\"09:30\"}}");
             return response;
    }

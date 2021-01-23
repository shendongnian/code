    public HttpResponseMessage GetInternet(int id) {
        using(var context = new InternetDbContext()) {
            var result =
               (from internet in context.Internets
                where internet.Id.Equals(id)
                select internet).FirstOrDefault();
            if(result != null)
               Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }

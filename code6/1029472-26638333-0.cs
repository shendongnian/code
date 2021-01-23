    public HttpResponseMessage Get()
    {
        var studentercord = _db.Student_sp().ToList();
        InfoModel objmodel = new InfoModel();
        objmodel.infoData = new List<info>();
        foreach (var item in studentercord.ToList())
        {
            objmodel.infoData.Add(new info { StudentID = item.StudentID, 
                                             LastName = item.LastName, 
                                             FirstName = item.FirstName, 
                                             EnrollmentDate = item.EnrollmentDate, 
                                             MiddleName = item.MiddleName });
        }
        return Request.CreateResponse(HttpStatusCode.OK, objmodel.infoData);
        //or return Request.CreateResponse(HttpStatusCode.OK, objmodel);
        //depending what your client expects...
    }

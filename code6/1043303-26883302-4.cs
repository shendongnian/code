    public PartialViewResult GetAllClassroom()
        {
            Guid entityId = new Guid();
            var searchClassRooms = from m in db.Forms
                                   where m.FormTypeEnumId == "CLASSROOM" && m.FormTitle.ToUpper() == "Add a Classroom".ToUpper() && m.EntityId == entityId
                                   join fs in db.FormSubmits on m.FormId equals fs.FormId
                                   select new Result // adding the Result to be strongly typed view
                                   {
                                       FormId = m.FormId,
                                       FormSubmitsId = fs.FormSubmitId,
                                       FormTitle = fs.FormTitle,
                                       CreatedOn = fs.CreatedOn
                                   };
    
            return PartialView("_getClassRoom", searchClassRooms.Distinct().OrderByDescending(s => s.CreatedOn).ToList());
        }

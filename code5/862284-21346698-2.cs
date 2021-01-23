    public ActionResult PostClassroom(CreateClassroomModel model)
    {
        var school = _db.Schools.FirstOrDefault(x => x.Name == model.SchoolName)
            ?? new School { Name = model.SchoolName };
        var classroom = new Classroom
        {
            RoomNumber = model.RoomNumber,
            School = school,
        };
        _db.Classrooms.Add(classroom);
        _db.SaveChanges();
        return RedirectToAction("CreateClassroomSuccess");
    }

    public class CreateClassroomModel
    {
        public string SchoolName { get; set; }
        public int RoomNumber { get; set; } 
    }
    
    public Task<ActionResult> PostClassroom(CreateClassroomModel model)
    {
        var school = await _db.Schools
            .FirstOrDefaultAsync(x => x.Name == model.SchoolName)
            ?? new School { Name = model.SchoolName };
        var classroom = new Classroom
        {
            RoomNumber = model.RoomNumber,
            School = school,
        };
        _db.Classrooms.Add(classroom);
        await _db.SaveChangesAsync();
    }

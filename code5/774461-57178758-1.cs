C#
// GET: api/GetStudent
     
public Response Get() {
    return StoredProcedure.GetStudent();
}
public static Response GetStudent() {
    using (var db = new dal()) {
        var student = db.Database.SqlQuery<GetStudentVm>("GetStudent").ToList();
        return new Response {
            Sucess = true,
            Message = student.Count() + " Student found",
            Data = student
        };
    }
}

    var db = conection.GetDatabase("school");
    var collection = db.GetCollection<Teacher>("teachers"); // Or your collection Name
    string mailForSearch="teacher@school.com"; // param for search in linq
    var allCoursesBson = collection.Find(x => x.Mail == mailForSearch).Project(Builders<Teacher>.Projection.Include(x => x.Courses).Exclude("_Id")).ToList();
    // allCoursesBson is BsonDocument list, then use a first BsonDocument an convert to string for convert to IEnumerable<Courses> type with  BsonSerializer.Deserialize
    string allCoursesText = resp.FirstOrDefault()[0].ToString();
    IEnumerable<Courses> allCourses = BsonSerializer.Deserialize<IEnumerable<Courses>>(allCoursesText);

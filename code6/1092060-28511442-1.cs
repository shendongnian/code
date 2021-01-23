    public IEnumerable<StudentReadDTO> GetAll()
    {
        MongoCollection<Student> collection = Db.GetCollection<Student>("students");
        List<Student> students = collection.AsQueryable().ToList();
        return students.Select(p => AutoMapper.Mapper.DynamicMap<StudentReadDTO>(p));
    } 
    // this DTO should be used for POST and PUT (i.e where there is no id or the id 
    // is part of the URL) - after all, it doesn't make sense to send the id from the
    // client to the server
    public class StudentDTO
    {
        public string Name { get; set; }
    }
    // this should be used by reading operations, where the id is read from the server
    // inheritance in DTOs is a source of confusion and can be painful, but this trivial
    // type of inheritance will be fine
    public class StudentReadDTO : StudentDTO
    {
        public string Id { get; set; }
    }

    public class StudentRepo
    {
        public Student Get(Guid id)
        {
            using(var ctx = new AppDbContext())
            {
                return ctx.Students.FirstOrDefault(x=>x.Id == id);
            }
        }
    }

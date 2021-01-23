    public class StudentDbContext:DbContext
    {
        public DbSet<StudentPersonalInfo> StudentPersonalInfos { get; set; }
        public DbSet<EducationQualification> EducationQualifications { get; set; }
    }

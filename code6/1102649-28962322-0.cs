    public static class QuestionAutoMapperConfig
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Profile, ProfileDTO>()
                .ForMember(d => d.SchoolGrade,
                    op => op.ResolveUsing(o => MapGrade(o.SchoolGrade)));
        }
        public static SchoolGradeDTO MapGrade(string grade)
        {
            //TODO: function to map a string to a SchoolGradeDTO
            return EnumHelper<SchoolGradeDTO>.Parse(grade);
        }
    }

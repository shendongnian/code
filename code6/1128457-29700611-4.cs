    public class MyUserDTO
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
    public static class MyUserDtoExtensions
    {
        public static IQueryable<MyUserDTO> AsDto(this IQueryable<MyUserDBObject> source)
        {
            return 
                source
                .Select(x => new MyUserDTO()
                    {
                        Forename = u.Forename,
                        Surname = u.Surname
                    }
        }
    }

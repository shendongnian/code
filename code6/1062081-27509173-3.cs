    public class PersonUser
    {
        public Personuser(IConfiguration configuration, IPersonFactory personFactory)
        {
            Person person = personFactory.Create(configuration.Name);
        }
    }

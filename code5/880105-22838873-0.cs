    public class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            if (DbChecker.MySqlInUse)
                SetConfiguration(new MySqlEFConfiguration());
        }
    }

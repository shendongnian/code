    public class MyEntityClassConfig : EntityTypeConfiguration<MyEntityClassConfig>
    {
        public MyEntityClassConfig()
        {
            ToTable("My_Database_Table_Name");
            HasKey(table => table.Name_of_primary_key);
        }
    }

    public class City
    {
        public int Id { get; set; }
        public string LocalizationKey { get; set; }
        public City(string englishName)
        {
            LocalizationKey = Properties.Resources.ResourceManager.GetString(englishName);
        }
    }

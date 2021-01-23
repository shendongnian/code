    public class MainModels
    {
        public MainModels()
        {
            Menu = new ObservableCollection<Menu>(GetMenuItems());
        }
        public ObservableCollection<Menu> Menu { get; private set; }
        /// <summary>
        /// Factory method to return all "known" menu items.
        /// </summary>
        /// 
        private static IEnumerable<Menu> GetMenuItems()
        {
            var items = new[]
                {
                    new Menu() { IconThumb = "/Photos/align_justify-50.png" };
                    new Menu() { IconThumb = "/Photos/music_video-50.png" };
                    new Menu() { IconThumb = "/Photos/christmas_star-50.png" };
                    new Menu() { IconThumb = "/Photos/user-50.png" };
                }
                .ToList()
                .AsReadOnly();
            return items;
        }
    }

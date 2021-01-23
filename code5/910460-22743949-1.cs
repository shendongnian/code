    public class Activity
    {
        public string Type { get; private set; }
        public string Description { get; private set; }
    
        public Activity(string type, string description)
        {
             Type = type;
             Description = description;
        }
        public static List<Activity> LoadActivities(XDocument doc)
        {
            return doc.Root
                      .Elements("Activity")
                      .Select(el => new Activity((string) el.Attribute("Type"),
                                                 el.Value));
                      .ToList();
        }
        public static List<Activity> LoadActivities()
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists("Activities.xml"))
                {
                     using (var stream = store.OpenFile("Activities.xml",
                                                        FileMode.Open))
                     {
                         return LoadActivities(XDocument.Load(stream));
                     }
                }
            }
            // No user file... load the default activities
            return LoadActivities(XDocument.Load("Assets/Activities.xml"));
        }
    }
    ...
    namespace ActivityManager
    {
        public partial class MainPage : PhoneApplicationPage
        {
            private List<Activity> activities;
            private Random random;
            private int actualActivityNumber;
    
    
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                activities = Activity.LoadActivities();
                // Initialize this *once* - not once per click
                random = new Random();
            }
    
    
            private void RandomButton_Click(object sender, RoutedEventArgs e)
            {
                int index = random.Next(activities.Count);
                RandomTextBox.Text = activities[index].Description;
            }
        }
    }

    public partial class Page2 : PhoneApplicationPage
    {
        public static async Task<Page2> Create()
        {
            var page = new Page2();
            await page.getWritings();
            return page;
        }
        List<Writing> writings;
        private Page2()
        {
            InitializeComponent();
        }
        private async Task getWritings()
        {
            string jsonData = await JsonDataManager.GetJsonAsync("1");
            JObject obj = JObject.Parse(jsonData);
            JArray array = (JArray)obj["posts"];
            for (int i = 0; i < array.Count; i++)
            {
                Writing writing = new Writing();
                writing.content = JsonDataManager.JsonParse(array, i, "content");
                writing.date = JsonDataManager.JsonParse(array, i, "date");
                writing.image = JsonDataManager.JsonParse(array, i, "url");
                writing.summary = JsonDataManager.JsonParse(array, i, "excerpt");
                writing.title = JsonDataManager.JsonParse(array, i, "title");
                writings.Add(writing);
            }
            myLongList.ItemsSource = writings;
        }
    }

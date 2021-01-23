    public class ViewModel2: AsyncBindableBase
    {
        public IEnumerable<Writing> Writings
        {
            get { return Property.Get(GetWritingsAsync); }
        }
        private async Task<IEnumerable<Writing>> GetWritingsAsync()
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
                yield return writing;
            }
        }
    }

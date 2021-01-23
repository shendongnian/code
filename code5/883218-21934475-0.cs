	[JsonObject]
	public class FavoriteColor
	{
		public FavoriteColor()
		{}
		public FavoriteColor(string title, string text)
		{
			Title = title;
			Text = text;
		}
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }
		[JsonProperty(PropertyName = "text")]
		public string Text { get; set; }
	}
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Append new objects to your file
        private async Task Append()
        {
            // Read file content and deserialize
            string content = await ReadAsync("json.txt");
            var colors = new List<FavoriteColor>();
            if (!string.IsNullOrWhiteSpace(content))
                colors.AddRange(JsonConvert.DeserializeObject<List<FavoriteColor>>(content));
            // Add your new favorite color!
            var fav = new FavoriteColor("new", "new color");
            colors.Add(fav);
            // Writo back to file
            await WriteAsync("json.txt", JsonConvert.SerializeObject(colors));
        }
        // Async read
        private async Task<string> ReadAsync(string file)
        {
            if (!File.Exists(file))
                return null;
            string content;
            using (var fileStream = File.OpenRead(file))
            {
                byte[] buffer = new byte[fileStream.Length];
                await fileStream.ReadAsync(buffer, 0, (int)fileStream.Length);
                content = Encoding.UTF8.GetString(buffer);
            }
            return content;
        }
        // Async write
        private async Task WriteAsync(string file, string content)
        {
            using (var fileStream = File.OpenWrite(file))
            {
                byte[] buffer = (new UTF8Encoding()).GetBytes(content);
                await fileStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }

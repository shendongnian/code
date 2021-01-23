   	public class PostCount
	{
		public int total_posts { get; set; }
		public int sfw_total_posts { get; set; }
		public int use { get; set; }
	}
	public class Thumbnail
	{
		public int w { get; set; }
		public int h { get; set; }
	}
	public class Post
	{
		public int guid { get; set; }
		public int wp_id { get; set; }
		public string type { get; set; }
		public string title { get; set; }
		public string path { get; set; }
		public int publish_start { get; set; }
		public string author { get; set; }
		public string web_url { get; set; }
		public string nsfw { get; set; }
		public int modified { get; set; }
		public string video { get; set; }
		public int likes { get; set; }
		public int dislikes { get; set; }
		public int main_category_id { get; set; }
		public List<Thumbnail> thumbnails { get; set; }
		public int comments { get; set; }
	}
	public class LatestChive
	{
		public PostCount post_count { get; set; }
		public int posts_per_page { get; set; }
		public List<Post> posts { get; set; }
		public string server { get; set; }
		public double time { get; set; }
	}

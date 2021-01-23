	public class MyComments
	{
		public string id { get; set; }
		public string text { get; set; }
		public Attachment attachment { get; set; }
		public class Attachment
		{
			public Media media { get; set; }
		}
		
		public class Media 
		{
			// changed `Image image` to `Image[] photos`:
			public Image[] photos{ get; set; }
		}
		
		public class Image 
		{
			public string src { get; set; }
		}
	}

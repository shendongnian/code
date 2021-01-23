	public class Post // <post>
	{
		int PostId { get; set; } // <id>307</id>
		int FromId { get; set; } // <<from_id>123</from_id>
		int ToId { get; set; } // <<to_id>123</to_id>
		DateTime PostDate { get; set; } // <<date>123892128</date>
		string PostType { get; set; } // <<post_type>post</post_type>
		string Text { get; set; } // <<text>Smth TExt</text>
		List<PostAttachment> Attachments { get; set; } // <attachments list="true">
	}
	
	public class PostAttachment // <attachment>
	{
      string AttachmentType { get; set; } // <type>photo</type>
      List<Photo> AttachedPhotos { get; set; } // <photo>
	}
	
	public class Photo 
	{
		int PhotoId { get; set; } // <pid>123</pid>
		int AId { get; set; } // <aid>-7</aid>
		int OwnerId { get; set; } // <owner_id>123</owner_id>
		string Source { get; set; } // <src>http://url1.jpg</src>
		string Source1Small { get; set; } // <src_small>http://url3.jpg</src_small>
		string Source2Big { get; set; } // <src_big>http://url2.jpg</src_big>
		string Source3XBig { get; set; } // <src_xbig>http://url4.jpg</src_xbig>
		string Source4XXBig { get; set; } // <src_xxbig>http://url5.jpg</src_xxbig>
		string Source5XXXBig { get; set; } // <src_xxxbig>http://url6.jpg</src_xxxbig>
		int Width { get; set; } // <width>990</width>
		int Height { get; set; } // <height>1188</height>
		string Text { get; set; } // <text/>
		DateTime CreatedDate { get; set; } // <created>135</created>
		int AccessKey { get; set; } // <access_key>67</access_key>
	}

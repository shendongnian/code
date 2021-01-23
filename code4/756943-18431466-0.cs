    public static string InsertWidgets(string input)
	{
		input = SocialMedia(input);
		input = GetBlogPosts(input);
		input = RecentBlogs(input);
		input = ContactForm(input);
		return input;
	}
	

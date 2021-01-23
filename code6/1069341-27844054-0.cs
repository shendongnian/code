    public static Task<IEnumerable<YourModel>> GetFiles(UserName userName)
		{
			return new ParseQuery<YourModel> ()
				.Where (x => x.userName == userName)
				.FindAsync();
		}

    // Domain Model example
    class Question
	{
		public String Text { get; set; }
		public String Author { get; set; 
		public IEnumerable<Reply> Replies { get; set; }
	}
    // Domain Model example
	class Reply
	{
		public String Author { get; set; }	
		public String Text { get; set; }
	}
    // DataContext example
	class WhatYouUseAsDataContext
	{
		public Question Question { get; set; } 
        // Your replies -- this is what your ListView binds to.
		public IEnumerable<ReplyViewModel> Replies { get; set; } 
		public WhatYouUseAsDataContext()
		{
			Question = SomeWayToGetTheQuestion();
			Replies = Question.Replies.Select(reply => new ReplyViewModel()
			{
				Reply = reply,
				QuestionAuthor = Question.Author
			});
		}
	}
    // Newly introduced viewmodel class
	class ReplyViewModel
	{
		public Reply Reply { get; set; }
		public String QuestionAuthor { get; set; }
	}

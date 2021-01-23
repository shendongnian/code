	public class MySession
    {
        public static MySession Instance
        {
			public Dictionary<QuestionID, AnswerID> QnsAndAnswers { get; set; }
		
            get 
			{
                MySession session = (MySession)HttpContext.Current.Session["__MySession__"];
				
				if (session == null)
				{
					session = new MySession();
					HttpContext.Current.Session["__MySession__"] = session;
				}
				return session;
			}
        }
    }

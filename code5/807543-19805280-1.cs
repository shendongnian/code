	public class MySession
    {
        public static MySession Instance
        {
            // this is the element you store the question and answer in by using MySession.Instance.QnsAndAnswer.Add(qnID, ansId);
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

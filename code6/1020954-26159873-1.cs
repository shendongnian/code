      public class StringReverser : IStringReverser
      {
	      [LoggingAspect]
          public string Reverse(string text)
	      {
		    if (text == null)
			   return null;
		    return new string(text.Reverse().ToArray());
	     }
      }

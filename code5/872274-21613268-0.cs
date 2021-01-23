	public class MyClass {
		private MyClass(ResultsOfParse data) {
			...
		}
		public MyClass(string data) : this(Parse(data)) {
			// nothing to do, the other constructor did all the work
		}
		private static ResultsOfParse Parse(string data) {
			// parse the string
			// put all necessary data into ResultsOfParse and return it
		}
		
		private class ResultsOfParse {
			// contains everything the constructor of MyClass needs
		}
	}

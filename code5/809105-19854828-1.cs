	public class Test1
	{
		public Test1() { }
		public Test1(int i) { }
		public Test1(int i) { } /* Syntax error 'Test already defines a member called Test with the same parameter types */
	}
	public class Test2
	{
		public Test2() { }
		public Test2(int i) { }
		public Test2(int i, int j) { }
	}

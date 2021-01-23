	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.IO;
	namespace DriveInfos
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            MyProgramContext prog = new MyProgramContext();
	            prog.propertyInt = 5;
	            Console.WriteLine(prog.propertyInt);
	            Console.Read();
	        }
	        class MyProgramContext
	        {
	            public int propertyInt
	            {
	                get { return 1; }
	                set { Console.WriteLine(value); }
	            }
	        }
	    }
	}

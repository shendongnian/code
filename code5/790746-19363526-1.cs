        // Original delegate syntax required  
        // initialization with a named method.
        TestDelegate testDelA = new TestDelegate(M);
        // C# 2.0: A delegate can be initialized with 
        // inline code, called an "anonymous method." This
        // method takes a string as an input parameter.
        TestDelegate testDelB = delegate(string s) { Console.WriteLine(s); };
        // C# 3.0. A delegate can be initialized with 
        // a lambda expression. The lambda also takes a string 
        // as an input parameter (x). The type of x is inferred by the compiler.
        TestDelegate testDelC = (x) => { Console.WriteLine(x); };

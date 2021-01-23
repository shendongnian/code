    using System;
    using System.Reflection;
    
    [assembly:AssemblyKeyFileAttribute("MyPublicKey.snk")]
    [assembly:AssemblyDelaySignAttribute(true)]
    
    namespace MyNamespace
    {
    	public class MyClass { }
    }

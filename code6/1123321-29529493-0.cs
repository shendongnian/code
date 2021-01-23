    using namespace System;
    public ref class HelloWorldC { 
    
    public:
    // Provide .NET interop and garbage collecting to the pointer.
    CSharpHelloWorld^ t;
    HelloWorldC() {
        t = gcnew CSharpHelloWorld();
        // Assign the reference a new instance of the object
    }
    // This inline function is called from the C++ Code
    void callCSharpHelloWorld() {
        t->displayHelloWorld();
    }
    };

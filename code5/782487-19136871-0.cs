    using namespace System::Collections::Generic;
    
    ref class MyClass
    {
    public:
        generic <typename T>
        static List<T>^ CreateList();
    };                                    // <== note semi-colon here.

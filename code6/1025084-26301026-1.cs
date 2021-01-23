    public ref class CppCLIClass
    {
    public:
        static void Bar()
        {
            try
            {
                array<Byte>^ fooResult = CSharpClass::Foo();
                // Success, no error occurred.
            }
            catch (SomeException^ e)
            {
                // An error occurred.
            }
        }
    }

    using namespace System;
    using namespace ClassLibrary1;
    int main(array<System::String ^> ^args)
    {
       auto o = gcnew Implementation();
       o->Get(gcnew SomeClass());
       o->Get(gcnew SomeClass(), gcnew SomeClass1());
       o->Get(gcnew SomeClass(), gcnew SomeClass2());
       
        Console::WriteLine(L"Hello World");
        return 0;
    }

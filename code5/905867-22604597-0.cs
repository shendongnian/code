    #using "MyCSharpProject.DLL"
    using namespace MyCSharpNamespace;
    ...
    gcroot<CPersoana^> pPersona = gcnew CPersoana();
    CString sFileName = <path to file>;
    pPersona->LoadFromFile(gcnew System::String(sFileName));
    // LoadFromFile would be a member function in the CPersoana class
    // like bool LoadFromFile(string sFileName)
    CString sName(pPersona->Name->ToString();
    ...

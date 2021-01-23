    extern "C" _declspec(dllexport) void _stdcall WORD(string name ,string cpu)
    {
        System::String ^managedName = gcnew System::String(name.c_str());
        System::String ^managedCpu = gcnew System::String(cpu.c_str());
        return CsharpDLL::WORD(managedName, managedCpu);
    }

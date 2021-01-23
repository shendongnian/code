    extern "C" __declspec char* LogMain();
    {
        //Put your code here..
        //return the char*.
    }
    
    [DllImport("ChatLib.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern StringBuilder LogMain();

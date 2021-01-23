    namespace MyNameSpace
    {
       public class MyWrapper 
       {
           // passing an int to the native DLL
           [DllImport("Vendor.DLL")]
           public static extern int DllFunc1(int hModule, int nData);
           // passing a string to a native DLL expecting null terminated raw wide characters //
           [DllImport("Vendor.DLL", CharSet=CharSet.Unicode )]
           public static extern int Dllszset(int hModule, string text);
       }
    }

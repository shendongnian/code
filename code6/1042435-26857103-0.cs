    using System.Runtime.InteropServices;
    // ...
    var data = new double[4096];
    Marshal.Copy(pointer, data, 0, 4096);
    // process data here

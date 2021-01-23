    // You will probably have to free in some way Input and Output
    delegate int GetResponseD(int Code, out IntPtr Input, out IntPtr OutPut);
    static void Main()
    {
        IntPtr input, output;
        GetResponseD grd = null; // something
        int res = grd(1, out input, out output);
        var input2 = new byte[90];
        var output2 = new byte[90];
        Marshal.Copy(input, input2, 0, input2.Length);
        Marshal.Copy(output, output2, 0, output2.Length);
        // Remember that you have to free input and output!
    }

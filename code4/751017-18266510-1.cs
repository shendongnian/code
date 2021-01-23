    // You will probably have to free in some way Input and Output
    delegate int GetResponseD(int Code, ref IntPtr Input, ref IntPtr OutPut);
    static void Main()
    {
        IntPtr input = IntPtr.Zero, output = IntPtr.Zero;
        GetResponseD grd = null; // something
        int res = grd(1, out input, out output);
        var input2 = new byte[90];
        var output2 = new byte[90];
        Marshal.Copy(input, input2, 0, input2.Length);
        Marshal.Copy(output, output2, 0, output2.Length);
        // Remember that you have to free input and output!
    }

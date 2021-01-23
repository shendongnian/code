    string GetByteString(double d)
    {
        return string.Join("", BitConverter.GetBytes(d).Select(b=>b.ToString("X2")));
    }
    string GetByteString(float f)
    {
        return string.Join("", BitConverter.GetBytes(f).Select(b=>b.ToString("X2")));
    }
    double vd = vTHREE_FIFTHS;
    double d = THREE_FIFTHS;
    const double cd = THREE_FIFTHS;
    float f = THREE_FIFTHS;
    const double cd2 = 3d / 5d;
    double d2 = 3d / 5d;
    
    // doubles
    Console.WriteLine(GetByteString((double)THREE_FIFTHS));
    Console.WriteLine(GetByteString(vd));
    Console.WriteLine(GetByteString(d));
    Console.WriteLine(GetByteString(cd));
    Console.WriteLine(GetByteString(cd2));
    Console.WriteLine(GetByteString(d2));
    
    // floats
    Console.WriteLine(GetByteString(f));
    Console.WriteLine(GetByteString(vTHREE_FIFTHS));
    Console.WriteLine(GetByteString(THREE_FIFTHS));
    prints this:
    333333333333E33F
    000000403333E33F <-- this is the only one that was actually converted from a 32-bit float value to a double
    333333333333E33F
    333333333333E33F
    333333333333E33F
    333333333333E33F
    9A99193F
    9A99193F
    9A99193F

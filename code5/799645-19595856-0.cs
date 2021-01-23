    void Main()
    {
            const int ONE_MILLION = 1000000;
    
            float THREEsng = 3f;
            float FIVEsng = 5f;
            float vTHREE_FIFTHS = THREEsng / FIVEsng;
    
            const float THREE_FIFTHS = 3f / 5f;
    
            Console.WriteLine("Three Fifths: {0}", THREE_FIFTHS.ToString("F10"));
            float asSingle = 0f;
            double asDouble = 0d;
            decimal asDecimal = 0M;
    
            for (int i = 0; i < ONE_MILLION; i++)
            {
                asSingle += (float) THREE_FIFTHS;
                asDouble += (double) THREE_FIFTHS;
                asDecimal += (decimal) THREE_FIFTHS;
            }
            Console.WriteLine("Six Hundred Thousand: {0:F10}", THREE_FIFTHS * ONE_MILLION);
            Console.WriteLine("Single: {0}", asSingle.ToString("F10"));
            Console.WriteLine("Double: {0}", asDouble.ToString("F10"));
            Console.WriteLine("Decimal: {0}", asDecimal.ToString("F10"));
            Console.WriteLine(GetByteString((float) THREE_FIFTHS));
            Console.WriteLine(GetByteString((double) THREE_FIFTHS));
            Console.WriteLine(GetByteString((decimal) THREE_FIFTHS));
    
            Console.WriteLine("vThree Fifths: {0}", vTHREE_FIFTHS.ToString("F10"));
            asSingle = 0f;
            asDouble = 0d;
            asDecimal = 0M;
    
            for (int i = 0; i < ONE_MILLION; i++)
            {
                asSingle += (float) vTHREE_FIFTHS;
                asDouble += (double) vTHREE_FIFTHS;
                asDecimal += (decimal) vTHREE_FIFTHS;
            }
            Console.WriteLine("Six Hundred Thousand: {0:F10}", vTHREE_FIFTHS * ONE_MILLION);
            Console.WriteLine("Single: {0}", asSingle.ToString("F10"));
            Console.WriteLine("Double: {0}", asDouble.ToString("F10"));
            Console.WriteLine("Decimal: {0}", asDecimal.ToString("F10"));
            Console.WriteLine(GetByteString((float) vTHREE_FIFTHS));
            Console.WriteLine(GetByteString((double) vTHREE_FIFTHS));
            Console.WriteLine(GetByteString((decimal) vTHREE_FIFTHS));
    
    }
    
    // Define other methods and classes here
    string GetByteString(double d)
    {
        return "#" + string.Join("", BitConverter.GetBytes(d).Select(b=>b.ToString("X2")));
    }
    string GetByteString(decimal d)
    {
        return "D" + string.Join("", Decimal.GetBits(d).Select(b=>b.ToString("X8")));
    }
    string GetByteString(float f)
    {
        return "S" + string.Join("", BitConverter.GetBytes(f).Select(b=>b.ToString("X2")));
    }

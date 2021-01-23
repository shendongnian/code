        public Test Write (bool data)
        {
            Content.Write(data);
            return this;
        }
        public Test Write (byte data)
        {
            Content.Write(data);
            return this;
        }
        public Test Write (byte[] data)
        {
            Content.Write(data);
            return this;
        }
        public Test Write (char data)
        {
            Content.Write(data);
            return this;
        }
        public Test Write (char[] data)
        {
            Content.Write(data);
            return this;
        }
        // ...
    This method is very verbose, but it is the only that provides compile-time checks of arument types and is the most performant as it chooses overloads and compile-time. Furthermore, these methods are likely to be inlined.
    In cases like this, I usually use a T4 script which generates code like above based on Reflection. Create a TT file, enumerate `Write` overloads of `BinaryWriter`, generate code.

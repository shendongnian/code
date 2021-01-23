    public class VISCIIEncoding : Encoding
    {
        private VISCIIEncoder encoder;
        private VISCIIDecoder decoder;
        protected VISCIIEncoder Encoder
        {
            get
            {
                // Lazy creation of Encoder, that is changed if EncoderFallback is changed
                if (object.ReferenceEquals(encoder, null))
                {
                    encoder = new VISCIIEncoder();
                }
                if (!object.ReferenceEquals(EncoderFallback, encoder.Fallback))
                {
                    encoder.Fallback = EncoderFallback;
                }
                return encoder;
            }
        }
        protected VISCIIDecoder Decoder
        {
            get
            {
                // Lazy creation of Encoder, that is changed if EncoderFallback is changed
                if (object.ReferenceEquals(decoder, null))
                {
                    decoder = new VISCIIDecoder();
                }
                if (!object.ReferenceEquals(DecoderFallback, decoder.Fallback))
                {
                    decoder.Fallback = DecoderFallback;
                }
                return decoder;
            }
        }
        public override string EncodingName
        {
            get
            {
                return "VISCII";
            }
        }
        public override bool IsSingleByte
        {
            get
            {
                return true;
            }
        }
        public override Encoder GetEncoder()
        {
            return new VISCIIEncoder();
        }
        public override Decoder GetDecoder()
        {
            return new VISCIIDecoder();
        }
        public override int GetByteCount(char[] chars, int index, int count)
        {
            return Encoder.GetByteCount(chars, index, count, true);
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return Encoder.GetBytes(chars, charIndex, charCount, bytes, byteIndex, true);
        }
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return Decoder.GetCharCount(bytes, index, count);
        }
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            return Decoder.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
        }
        public override int GetMaxByteCount(int charCount)
        {
            return charCount;
        }
        public override int GetMaxCharCount(int byteCount)
        {
            return byteCount;
        }
    }
    public class VISCIIEncoder : Encoder
    {
        public static readonly Dictionary<char, byte> VISCIIs;
        protected char? buffer { get; set; } // Buffer for High/Low surrogates
        static VISCIIEncoder()
        {
            VISCIIs = new Dictionary<char, byte>();
            for (int i = 0; i < VISCIIDecoder.Unicodes.Length; i++)
            {
                VISCIIs[VISCIIDecoder.Unicodes[i]] = (byte)i;
            }
        }
        public override int GetByteCount(char[] chars, int index, int count, bool flush)
        {
            int ret = 0;
            if (count > 0)
            {
                int count2 = index + count;
                for (; index < count2; index++)
                {
                    char ch = chars[index];
                    if (buffer != null)
                    {
                        if (FallbackBuffer.Fallback(buffer.Value, ch, index))
                        {
                            while (FallbackBuffer.Remaining > 0)
                            {
                                FallbackBuffer.GetNextChar();
                                ret++;
                            }
                        }
                        buffer = null;
                    }
                    else
                    {
                        // High/low surrogate handling, done through buffer
                        if (char.IsHighSurrogate(ch))
                        {
                            buffer = ch;
                        }
                        else
                        {
                            byte b;
                            if (VISCIIs.TryGetValue(ch, out b))
                            {
                                // Recognized character
                                ret++;
                            }
                            else
                            {
                                // Fallback (optional)
                                if (FallbackBuffer.Fallback(ch, index))
                                {
                                    while (FallbackBuffer.Remaining > 0)
                                    {
                                        FallbackBuffer.GetNextChar();
                                        ret++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (flush)
            {
                buffer = null;
            }
            return ret;
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush)
        {
            int charCount2 = charIndex + charCount;
            int byteIndex2 = byteIndex;
            for (; charIndex < charCount2; charIndex++)
            {
                char ch = chars[charIndex];
                if (buffer != null)
                {
                    if (FallbackBuffer.Fallback(buffer.Value, ch, charIndex))
                    {
                        while (FallbackBuffer.Remaining > 0)
                        {
                            if (byteIndex2 >= bytes.Length)
                            {
                                throw new ArgumentException();
                            }
                            byte b;
                            if (!VISCIIs.TryGetValue(FallbackBuffer.GetNextChar(), out b))
                            {
                                throw new EncoderFallbackException();
                            }
                            // TODO Check valid character!
                            bytes[byteIndex2] = b;
                            byteIndex2++;
                        }
                    }
                    buffer = null;
                }
                else
                {
                    // High/low surrogate handling, done through buffer
                    if (char.IsHighSurrogate(ch))
                    {
                        buffer = ch;
                    }
                    else
                    {
                        byte b;
                        if (VISCIIs.TryGetValue(ch, out b))
                        {
                            // Recognized character
                            if (byteIndex2 >= bytes.Length)
                            {
                                throw new ArgumentException();
                            }
                            bytes[byteIndex2] = b;
                            byteIndex2++;
                        }
                        else
                        {
                            // Fallback (optional)
                            if (FallbackBuffer.Fallback(ch, byteIndex2))
                            {
                                while (FallbackBuffer.Remaining > 0)
                                {
                                    if (byteIndex2 >= bytes.Length)
                                    {
                                        throw new ArgumentException();
                                    }
                                    if (!VISCIIs.TryGetValue(FallbackBuffer.GetNextChar(), out b))
                                    {
                                        throw new EncoderFallbackException();
                                    }
                                    // TODO Check valid character!
                                    bytes[byteIndex2] = b;
                                    byteIndex2++;
                                }
                            }
                        }
                    }
                }
            }
            if (flush)
            {
                buffer = null;
            }
            return byteIndex2 - byteIndex;
        }
    }
    public class VISCIIDecoder : Decoder
    {
        public static readonly char[] Unicodes = new char[] 
        {
            '\u0000', '\u0001', '\u1EB2', '\u0003', '\u0004', '\u1EB4', '\u1EAA', '\u0007', 
            '\u0008', '\u0009', '\u000A', '\u000B', '\u000C', '\u000D', '\u000E', '\u000F', 
            '\u0010', '\u0011', '\u0012', '\u0013', '\u1EF6', '\u0015', '\u0016', '\u0017', 
            '\u0018', '\u1EF8', '\u001A', '\u001B', '\u001C', '\u001D', '\u1EF4', '\u001F', 
            '\u0020', '\u0021', '\u0022', '\u0023', '\u0024', '\u0025', '\u0026', '\u0027', 
            '\u0028', '\u0029', '\u002A', '\u002B', '\u002C', '\u002D', '\u002E', '\u002F', 
            '\u0030', '\u0031', '\u0032', '\u0033', '\u0034', '\u0035', '\u0036', '\u0037', 
            '\u0038', '\u0039', '\u003A', '\u003B', '\u003C', '\u003D', '\u003E', '\u003F', 
            '\u0040', '\u0041', '\u0042', '\u0043', '\u0044', '\u0045', '\u0046', '\u0047', 
            '\u0048', '\u0049', '\u004A', '\u004B', '\u004C', '\u004D', '\u004E', '\u004F', 
            '\u0050', '\u0051', '\u0052', '\u0053', '\u0054', '\u0055', '\u0056', '\u0057', 
            '\u0058', '\u0059', '\u005A', '\u005B', '\u005C', '\u005D', '\u005E', '\u005F', 
            '\u0060', '\u0061', '\u0062', '\u0063', '\u0064', '\u0065', '\u0066', '\u0067', 
            '\u0068', '\u0069', '\u006A', '\u006B', '\u006C', '\u006D', '\u006E', '\u006F', 
            '\u0070', '\u0071', '\u0072', '\u0073', '\u0074', '\u0075', '\u0076', '\u0077', 
            '\u0078', '\u0079', '\u007A', '\u007B', '\u007C', '\u007D', '\u007E', '\u007F', 
            '\u1EA0', '\u1EAE', '\u1EB0', '\u1EB6', '\u1EA4', '\u1EA6', '\u1EA8', '\u1EAC', 
            '\u1EBC', '\u1EB8', '\u1EBE', '\u1EC0', '\u1EC2', '\u1EC4', '\u1EC6', '\u1ED0', 
            '\u1ED2', '\u1ED4', '\u1ED6', '\u1ED8', '\u1EE2', '\u1EDA', '\u1EDC', '\u1EDE', 
            '\u1ECA', '\u1ECE', '\u1ECC', '\u1EC8', '\u1EE6', '\u0168', '\u1EE4', '\u1EF2', 
            '\u00D5', '\u1EAF', '\u1EB1', '\u1EB7', '\u1EA5', '\u1EA7', '\u1EA9', '\u1EAD', 
            '\u1EBD', '\u1EB9', '\u1EBF', '\u1EC1', '\u1EC3', '\u1EC5', '\u1EC7', '\u1ED1', 
            '\u1ED3', '\u1ED5', '\u1ED7', '\u1EE0', '\u01A0', '\u1ED9', '\u1EDD', '\u1EDF', 
            '\u1ECB', '\u1EF0', '\u1EE8', '\u1EEA', '\u1EEC', '\u01A1', '\u1EDB', '\u01AF', 
            '\u00C0', '\u00C1', '\u00C2', '\u00C3', '\u1EA2', '\u0102', '\u1EB3', '\u1EB5', 
            '\u00C8', '\u00C9', '\u00CA', '\u1EBA', '\u00CC', '\u00CD', '\u0128', '\u1EF3', 
            '\u0110', '\u1EE9', '\u00D2', '\u00D3', '\u00D4', '\u1EA1', '\u1EF7', '\u1EEB', 
            '\u1EED', '\u00D9', '\u00DA', '\u1EF9', '\u1EF5', '\u00DD', '\u1EE1', '\u01B0', 
            '\u00E0', '\u00E1', '\u00E2', '\u00E3', '\u1EA3', '\u0103', '\u1EEF', '\u1EAB', 
            '\u00E8', '\u00E9', '\u00EA', '\u1EBB', '\u00EC', '\u00ED', '\u0129', '\u1EC9', 
            '\u0111', '\u1EF1', '\u00F2', '\u00F3', '\u00F4', '\u00F5', '\u1ECF', '\u1ECD', 
            '\u1EE5', '\u00F9', '\u00FA', '\u0169', '\u1EE7', '\u00FD', '\u1EE3', '\u1EEE', 
        };
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return count;
        }
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            if (byteCount < chars.Length - charIndex)
            {
                throw new ArgumentException();
            }
            int byteCount2 = byteCount + byteIndex;
            for (; byteIndex < byteCount2; byteIndex++, charIndex++)
            {
                chars[charIndex] = Unicodes[bytes[byteIndex]];
            }
            return byteCount;
        }
    }

    namespace Utilities
    {
        using System;
        using System.Collections.ObjectModel;
        using System.Linq;
        using System.Runtime.CompilerServices;
        using System.Text;
    
        /// <summary>
        /// VISCII (https://en.wikipedia.org/wiki/Vietnamese_Standard_Code_for_Information_Interchange)
        /// encoding for C#.
        /// Fast table-based implementation not based on MappedEncoding.
        /// Fully thread safe/reentrant (because VISCIIEncoder is fully thread
        /// safe/reentrant and VISCIIDecoder is always used with flush = true).
        /// </summary>
        public class VISCIIEncodingSimple : Encoding
        {
            // Taken from http://en.wikipedia.org/wiki/Vietnamese_Standard_Code_for_Information_Interchange
            public static readonly ReadOnlyCollection<char> Unicodes = Array.AsReadOnly(new char[] 
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
            });
    
            private VISCIIDecoder decoder;
            private VISCIIEncoder encoder;
    
            /// <summary>
            /// This should be thread safe. The worst case is that two instances
            /// of VISCIIDecoder are created at the same time, but this isn't
            /// a problem, because VISCIIDecoder as used in this class is 
            /// stateless.
            /// </summary>
            protected VISCIIDecoder Decoder
            {
                get
                {
                    VISCIIDecoder decoder2 = decoder;
    
                    // Lazy creation of Encoder
                    if (object.ReferenceEquals(decoder2, null))
                    {
                        decoder2 = decoder = new VISCIIDecoder();
                    }
    
                    DecoderFallback decoderFallback = DecoderFallback;
    
                    // If the Fallback has changed from the last call, update it
                    if (!object.ReferenceEquals(decoderFallback, null) && !object.ReferenceEquals(decoderFallback, decoder2.Fallback))
                    {
                        decoder2.Fallback = decoderFallback;
                    }
    
                    return decoder2;
                }
            }
    
            /// <summary>
            /// This should be thread safe. The worst case is that two instances
            /// of VISCIIEncoder are created at the same time, but this isn't
            /// a problem, because VISCIIEncoder as used in this class is 
            /// stateless.
            /// </summary>
            protected VISCIIEncoder Encoder
            {
                get
                {
                    VISCIIEncoder encoder2 = encoder;
    
                    // Lazy creation of Encoder
                    if (object.ReferenceEquals(encoder2, null))
                    {
                        encoder = encoder2 = new VISCIIEncoder();
                    }
    
                    EncoderFallback encoderFallback = EncoderFallback;
    
                    // If the Fallback has changed from the last call, update it
                    if (!object.ReferenceEquals(encoderFallback, null) && !object.ReferenceEquals(encoderFallback, encoder2.Fallback))
                    {
                        encoder2.Fallback = encoderFallback;
                    }
    
                    return encoder2;
                }
            }
    
            public override string BodyName
            {
                get
                {
                    return "viscii-simple";
                }
            }
    
            public override string EncodingName
            {
                get
                {
                    return BodyName;
                }
            }
    
            public override bool IsSingleByte
            {
                get
                {
                    return true;
                }
            }
    
            public override object Clone()
            {
                var encoding = (VISCIIEncodingSimple)base.Clone();
    
                // We reset the encoder and decoder of the cloned instance,
                // because otherwise they would be shared between the two
                // instances.
                encoding.decoder = null;
                encoding.encoder = null;
    
                return encoding;
            }
    
            public override Decoder GetDecoder()
            {
                return new VISCIIDecoder();
            }
    
            public override Encoder GetEncoder()
            {
                return new VISCIIEncoder();
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
                return Decoder.GetCharCount(bytes, index, count, true);
            }
    
            public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
            {
                return Decoder.GetChars(bytes, byteIndex, byteCount, chars, charIndex, true);
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
    
        /// <summary>
        /// Fully thread safe/reentrant.
        /// </summary>
        public class VISCIIDecoder : Decoder
        {
            private static readonly char[] Unicodes = VISCIIEncodingSimple.Unicodes.ToArray();
    
            public override int GetCharCount(byte[] bytes, int index, int count)
            {
                if (bytes == null)
                {
                    throw new ArgumentNullException("bytes");
                }
    
                if (index < 0 || index > bytes.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
    
                if (count < 0)
                {
                    throw new ArgumentOutOfRangeException("count");
                }
    
                if (index + count > bytes.Length)
                {
                    throw new ArgumentOutOfRangeException("bytes");
                }
    
                return count;
            }
    
            public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
            {
                if (bytes == null)
                {
                    throw new ArgumentNullException("bytes");
                }
    
                if (byteIndex < 0 || byteIndex > bytes.Length)
                {
                    throw new ArgumentOutOfRangeException("byteIndex");
                }
    
                if (byteCount < 0)
                {
                    throw new ArgumentOutOfRangeException("byteCount");
                }
    
                if (byteIndex + byteCount > bytes.Length)
                {
                    throw new ArgumentOutOfRangeException("bytes");
                }
    
                if (chars == null)
                {
                    throw new ArgumentNullException("chars");
                }
    
                if (charIndex < 0 || charIndex > chars.Length)
                {
                    throw new ArgumentOutOfRangeException("charIndex");
                }
    
                int byteCount2 = byteCount + byteIndex;
                int charIndex2 = charIndex;
    
                for (; byteIndex < byteCount2; byteIndex++)
                {
                    byte b = bytes[byteIndex];
    
                    if (charIndex2 == chars.Length)
                    {
                        throw new ArgumentException("chars");
                    }
    
                    // chars between 31 and 127 are equal in Unicode and VISCII
                    chars[charIndex2] = b >= 31 && b <= 127 ? (char)b : Unicodes[b];
                    charIndex2++;
                }
    
                return charIndex2 - charIndex;
            }
        }
    
        /// <summary>
        /// An instance is thread safe/fully reentrant if the methods are always
        /// called with flush = true.
        /// </summary>
        public class VISCIIEncoder : Encoder
        {
            private static readonly byte[] VISCIIs;
    
            // Buffer for High/Low surrogates. Note that this property is read
            // but not written if the methods are always used with flush = true.
            protected char HighSurrogate { get; set; }
    
            static VISCIIEncoder()
            {
                VISCIIs = new byte[1 + VISCIIEncodingSimple.Unicodes.Max()];
    
                for (int i = 0; i < VISCIIEncodingSimple.Unicodes.Count; i++)
                {
                    VISCIIs[VISCIIEncodingSimple.Unicodes[i]] = (byte)i;
                }
            }
    
            public override int GetByteCount(char[] chars, int index, int count, bool flush)
            {
                if (chars == null)
                {
                    throw new ArgumentNullException("chars");
                }
    
                if (index < 0 || index > chars.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
    
                if (count < 0)
                {
                    throw new ArgumentOutOfRangeException("count");
                }
    
                if (index + count > chars.Length)
                {
                    throw new ArgumentOutOfRangeException("chars");
                }
    
                // The fallbackBuffer is created on-demand. The instance 
                // FallbackBuffer isn't used because it wouldn't be thread safe.
                EncoderFallbackBuffer fallbackBuffer = null;
    
                char highSurrogate = HighSurrogate;
    
                int ret = 0;
    
                int count2 = index + count;
    
                for (; index < count2; index++)
                {
                    char ch = chars[index];
    
                    if (highSurrogate != 0)
                    {
                        if (fallbackBuffer == null)
                        {
                            fallbackBuffer = (Fallback ?? EncoderFallback.ReplacementFallback).CreateFallbackBuffer();
                        }
    
                        // If we have a High/Low surrogates couple, we pass them 
                        // together
                        if (char.IsLowSurrogate(ch))
                        {
                            if (fallbackBuffer.Fallback(highSurrogate, ch, index - 1))
                            {
                                HandleFallbackCount(fallbackBuffer, ref ret);
                            }
    
                            highSurrogate = '\0';
    
                            continue;
                        }
                        else
                        {
                            // First we pass the High surrogate to the Fallback
                            if (fallbackBuffer.Fallback(highSurrogate, index - 1))
                            {
                                HandleFallbackCount(fallbackBuffer, ref ret);
                            }
    
                            highSurrogate = '\0';
    
                            // Then we fall-through normal handling
                        }
                    }
    
                    if (ch < VISCIIs.Length && (VISCIIs[ch] != 0 || ch == '\0'))
                    {
                        ret++;
                    }
                    else
                    {
                        // High/low surrogate handling, done through buffer
                        if (char.IsHighSurrogate(ch))
                        {
                            highSurrogate = ch;
                        }
                        else
                        {
                            if (fallbackBuffer == null)
                            {
                                fallbackBuffer = (Fallback ?? EncoderFallback.ReplacementFallback).CreateFallbackBuffer();
                            }
    
                            // Fallback
                            if (fallbackBuffer.Fallback(ch, index))
                            {
                                HandleFallbackCount(fallbackBuffer, ref ret);
                            }
                        }
                    }
                }
    
                if (flush)
                {
                    if (highSurrogate != 0)
                    {
                        if (fallbackBuffer == null)
                        {
                            fallbackBuffer = (Fallback ?? EncoderFallback.ReplacementFallback).CreateFallbackBuffer();
                        }
    
                        if (fallbackBuffer.Fallback(highSurrogate, index - 1))
                        {
                            HandleFallbackCount(fallbackBuffer, ref ret);
                        }
                    }
                }
    
                return ret;
            }
    
            public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush)
            {
                if (chars == null)
                {
                    throw new ArgumentNullException("chars");
                }
    
                if (charIndex < 0 || charIndex > chars.Length)
                {
                    throw new ArgumentOutOfRangeException("charIndex");
                }
    
                if (charCount < 0)
                {
                    throw new ArgumentOutOfRangeException("charCount");
                }
    
                if (charIndex + charCount > chars.Length)
                {
                    throw new ArgumentOutOfRangeException("chars");
                }
    
                if (bytes == null)
                {
                    throw new ArgumentNullException("bytes");
                }
    
                if (byteIndex < 0 || byteIndex > bytes.Length)
                {
                    throw new ArgumentOutOfRangeException("byteIndex");
                }
    
                // The fallbackBuffer is created on-demand. The instance 
                // FallbackBuffer isn't used because it wouldn't be thread safe.
                EncoderFallbackBuffer fallbackBuffer = null;
    
                // Written only on flush = false
                char highSurrogate = HighSurrogate;
    
                int charCount2 = charIndex + charCount;
                int byteIndex2 = byteIndex;
    
                for (; charIndex < charCount2; charIndex++)
                {
                    char ch = chars[charIndex];
    
                    if (highSurrogate != 0)
                    {
                        if (fallbackBuffer == null)
                        {
                            fallbackBuffer = (Fallback ?? EncoderFallback.ReplacementFallback).CreateFallbackBuffer();
                        }
    
                        // If we have a High/Low surrogates couple, we pass them 
                        // together
                        if (char.IsLowSurrogate(ch))
                        {
                            if (fallbackBuffer.Fallback(highSurrogate, ch, charIndex - 1))
                            {
                                HandleFallbackWrite(fallbackBuffer, bytes, ref byteIndex2);
                            }
    
                            highSurrogate = '\0';
    
                            continue;
                        }
                        else
                        {
                            // First we pass the High surrogate to the Fallback
                            if (fallbackBuffer.Fallback(highSurrogate, charIndex - 1))
                            {
                                HandleFallbackWrite(fallbackBuffer, bytes, ref byteIndex2);
                            }
    
                            highSurrogate = '\0';
    
                            // Then we fall-through normal handling
                        }
                    }
    
                    byte b;
    
                    if (ch < VISCIIs.Length && ((b = VISCIIs[ch]) != 0 || ch == '\0'))
                    {
                        // Recognized character
                        WriteByte(bytes, byteIndex2, b);
                        byteIndex2++;
                    }
                    else
                    {
                        // High/low surrogate handling, done through buffer
                        if (char.IsHighSurrogate(ch))
                        {
                            highSurrogate = ch;
                        }
                        else
                        {
                            if (fallbackBuffer == null)
                            {
                                fallbackBuffer = (Fallback ?? EncoderFallback.ReplacementFallback).CreateFallbackBuffer();
                            }
    
                            // Fallback
                            if (fallbackBuffer.Fallback(ch, charIndex))
                            {
                                HandleFallbackWrite(fallbackBuffer, bytes, ref byteIndex2);
                            }
                        }
                    }
                }
    
                if (flush)
                {
                    if (highSurrogate != 0)
                    {
                        if (fallbackBuffer == null)
                        {
                            fallbackBuffer = (Fallback ?? EncoderFallback.ReplacementFallback).CreateFallbackBuffer();
                        }
    
                        if (fallbackBuffer.Fallback(highSurrogate, charIndex - 1))
                        {
                            HandleFallbackWrite(fallbackBuffer, bytes, ref byteIndex2);
                        }
                    }
                }
                else
                {
                    HighSurrogate = highSurrogate;
                }
    
                return byteIndex2 - byteIndex;
            }
    
            protected static void HandleFallbackCount(EncoderFallbackBuffer fallbackBuffer, ref int count)
            {
                while (fallbackBuffer.Remaining > 0)
                {
                    char ch = fallbackBuffer.GetNextChar();
    
                    if (!(ch < VISCIIs.Length && (VISCIIs[ch] != 0 || ch == '\0')))
                    {
                        throw new EncoderFallbackException();
                    }
    
                    count++;
                }
            }
    
            protected static void HandleFallbackWrite(EncoderFallbackBuffer fallbackBuffer, byte[] bytes, ref int byteIndex)
            {
                while (fallbackBuffer.Remaining > 0)
                {
                    char ch = fallbackBuffer.GetNextChar();
    
                    byte b;
    
                    if (!(ch < VISCIIs.Length && ((b = VISCIIs[ch]) != 0 || ch == '\0')))
                    {
                        throw new EncoderFallbackException();
                    }
    
                    WriteByte(bytes, byteIndex, b);
                    byteIndex++;
                }
            }
    
            // Remove the next line if using .NET < 4.5
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            protected static void WriteByte(byte[] bytes, int byteIndex, byte b)
            {
                if (byteIndex == bytes.Length)
                {
                    throw new ArgumentException("bytes");
                }
    
                bytes[byteIndex] = b;
            }
        }
    }

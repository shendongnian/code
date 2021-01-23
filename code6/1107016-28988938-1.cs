    using System;
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Text.RegularExpressions;
    public class XmlEncodingDetector
    {
        /// Detect the XML encoding by reading both the file stream as text-based and the encoding pseudoattribute of the XML header (if present)
        /// The encoding is detected using the guidelines specified in the http://www.w3.org/TR/xml/#sec-guessing' (XML W3C Specification).
        ///
        /// Returns the detected encoding or null if not detected</returns>
        public static Encoding DetectXmlFileEncoding(string xmlFileName)
        {
            using (FileStream xmlFileStream = File.OpenRead(xmlFileName))
            {
                return DetectXmlFileEncoding(xmlFileStream);
            }
        }
        /// Detect the XML encoding by reading both the file stream as text-based and the encoding pseudoattribute of the XML header (if present)
        /// The encoding is detected using the guidelines specified in the http://www.w3.org/TR/xml/#sec-guessing' (XML W3C Specification).
        ///
        /// Returns the detected encoding or null if not detected</returns>
        public static Encoding DetectXmlFileEncoding(FileStream xmlFileStream)
        {
            long originalPos = -1;
            Encoding encodingFound1 = null;
            Encoding encodingFound2 = null;
            try
            {
                originalPos = xmlFileStream.Position;
                // Reading a binary sample of the file in order to parse it
                byte[] sample = new byte[xmlFileStream.Length > 0x100 ? 0x100 : xmlFileStream.Length];
                xmlFileStream.Read(sample, 0, sample.Length);
                // look for the BOM of the file in the read sample
                encodingFound1 = DetectBOMBytes(sample);
                // if the encoding was not detected due to a missing or unrecognizable BOM, try to detect from the binary representation of the string "<?xml"
                Boolean checkPseudoAttribute = false;
                if (encodingFound1 == null)
                {
                    if (sample[0] == (byte)0x00 && sample[1] == (byte)0x3C && sample[2] == (byte)0x00 && sample[3] == (byte)0x3F)
                    {
                        // UTF-16BE or big-endian ISO-10646-UCS-2 or other encoding with a 16-bit code unit in big-endian order and ASCII characters encoded as ASCII values
                        // (the encoding declaration must be read to determine which)
                        encodingFound1 = Encoding.BigEndianUnicode;
                        checkPseudoAttribute = true;
                    }
                    else if (sample[0] == (byte)0x00 && sample[1] == (byte)0x00 && sample[2] == (byte)0x00 && sample[3] == (byte)0x3C)
                    {
                        // most probably utf-32BE (Encoding.GetEncoding(12001))
                        // (the encoding declaration must be read to determine which)
                        encodingFound1 = Encoding.GetEncoding(12001);
                        checkPseudoAttribute = true;
                    }
                    else if (sample[0] == (byte)0xFF && sample[1] == (byte)0xFE)
                    {
                        encodingFound1 = Encoding.Unicode;
                    }
                    else if (sample[0] == (byte)0xFE && sample[1] == (byte)0xFF)
                    {
                        encodingFound1 = Encoding.BigEndianUnicode;
                    }
                    else if (sample[0] == (byte)0x3C && sample[1] == (byte)0x00 && sample[2] == (byte)0x00 && sample[3] == (byte)0x00)
                    {
                        // (the encoding declaration must be read to determine which)
                        encodingFound1 = Encoding.UTF32;
                        checkPseudoAttribute = true;
                    }
                    else if (sample[0] == (byte)0x3C && sample[1] == (byte)0x00 && sample[2] == (byte)0x3F && sample[3] == (byte)0x00)
                    {
                        // UTF-16LE or little-endian ISO-10646-UCS-2 or other encoding with a 16-bit code unit in little-endian order and ASCII characters encoded as ASCII values
                        // (the encoding declaration must be read to determine which)
                        encodingFound1 = Encoding.Unicode;
                        checkPseudoAttribute = true;
                    }
                    else if (sample[0] == (byte)0x3C && sample[1] == (byte)0x3F && sample[2] == (byte)0x78 && sample[3] == (byte)0x6D)
                    {
                        // UTF-8, ISO 646, ASCII, some part of ISO 8859 or any other 7-bit, 8-bit
                        // (the encoding declaration must be read to determine which)
                        encodingFound1 = Encoding.ASCII;
                        checkPseudoAttribute = true;
                    }
                    else if (sample[0] == (byte)0x4C && sample[1] == (byte)0x6F && sample[2] == (byte)0xA7 && sample[3] == (byte)0x94)
                    {
                        encodingFound1 = Encoding.GetEncoding(37);    // IBM037 - IBM EBCDIC US-Canada"CP037";
                    }
                }   // if (encodingFound1 == null)
                // Now read the encoding pseudoattribute in the XML header, if present
                encodingFound2 = GetXmlDeclaredEncoding(sample, encodingFound1 ?? Encoding.UTF8);   // if I have no info, try with the most common (sigh)
                // compare the 2 found encoding and decided which is the right one
                Encoding winner = null;
                if (encodingFound1 == encodingFound2)
                {
                    winner = encodingFound2;
                }
                else if (encodingFound1 == null)
                {
                    winner = encodingFound2;
                }
                else if (encodingFound2 == null)
                {
                    winner = encodingFound1;
                }
                else if (checkPseudoAttribute)
                {
                    // Fine-tune the winner encoding. This is the most heuristic part, as some encoding
                    // can be overloaded. E.g. ASCII might be UTF-7, UTF-8, ISO-8859...
                    if (encodingFound1.Equals(Encoding.ASCII) &&
                            (encodingFound2.Equals(Encoding.UTF7) || encodingFound2.Equals(Encoding.UTF8) || encodingFound2.HeaderName.Contains("iso-8859")))
                    {
                        winner = encodingFound2;
                    }
                    else
                    {
                        // I'm not sure here if throw an exception or accept encodingFound1 or encodingFound2, 
                        // as both are not null and not equals
                        throw new XmlException(string.Format("{0} ({1}, {2})",
                                "The text encoding and the encoding pseudo-attribute of the XML header mismatch", 
                                encodingFound1, encodingFound2));
                    }
                }
                else
                {
                    // encodingFound1 and encodingFound2 are different so none win
                    throw new XmlException(string.Format("{0} ({1}, {2})",
                            "The text encoding and the encoding pseudo-attribute of the XML header mismatch",
                            encodingFound1, encodingFound2));
                }
                // return the detected encoding
                return winner;
            }
            finally
            {
                if (originalPos >= 0) xmlFileStream.Position = originalPos;
            }
        }
        
        #region private methods
        /// Search for the standard Begin of Message sequence to identify encoding
        /// Returns the possibily null identified encoding
        private static Encoding DetectBOMBytes(byte[] BOMBytes)
        {
            if (BOMBytes.Length < 2) return null;
            if (BOMBytes[0] == 0xFF && BOMBytes[1] == 0xFE
                    && (BOMBytes.Length < 4 || BOMBytes[2] != 0x00 || BOMBytes[3] != 0x00))
                return Encoding.Unicode;            // utf-16LE - Unicode UTF-16 little endian byte order
            if (BOMBytes[0] == 0xFE && BOMBytes[1] == 0xFF)
                return Encoding.BigEndianUnicode;   // utf-16BE - Unicode UTF-16 big endian byte order
            if (BOMBytes.Length < 3) return null;
            if (BOMBytes[0] == 0xEF && BOMBytes[1] == 0xBB && BOMBytes[2] == 0xBF)
                return Encoding.UTF8;               // utf-8
            if (BOMBytes[0] == 0x2B && BOMBytes[1] == 0x2F && BOMBytes[2] == 0x76)
                return Encoding.UTF7;               // note: Character encodings such as UTF-7 that make overloaded usage of ASCII-valued bytes may fail to be reliably detected
            if (BOMBytes.Length < 4) return null;
            if (BOMBytes[0] == 0xFF && BOMBytes[1] == 0xFE && BOMBytes[2] == 0x00 && BOMBytes[3] == 0x00)
                return Encoding.UTF32;              // utf-32LE - Unicode UTF-32 little endian byte order
            if (BOMBytes[0] == 0x00 && BOMBytes[1] == 0x00 && BOMBytes[2] == 0xFE && BOMBytes[3] == 0xFF)
                return Encoding.GetEncoding(12001); // utf-32BE - Unicode UTF-32 big endian byte order
            return null;
        }
        private static Encoding GetXmlDeclaredEncoding(byte[] sample, Encoding guessedEncoding)
        {
            // capture the encoding from the xml declaraion
            string contents = contents = GetStringFromByteArray(sample, guessedEncoding);
            string pattern = "<\\?xml\\sversion=\"1.0\"\\sencoding=\"(?<encoding>[\\w|-]+)\"";
            Match m = Regex.Match(contents, pattern, RegexOptions.ExplicitCapture);
            return (m.Groups["encoding"].Success) ? Encoding.GetEncoding(m.Groups["encoding"].Value) : null;
        }
        private static string GetStringFromByteArray(byte[] message, Encoding guessedEncoding)
        {
            // try to get the encoding from the byte array
            Encoding encodingFound = DetectBOMBytes(message);
            return (encodingFound != null)
                // for some reason, the default encodings don't detect/swallow their own preambles!!
                ? encodingFound.GetString(message, encodingFound.GetPreamble().Length, message.Length - encodingFound.GetPreamble().Length)
                : (DetectUnicodeInByteSampleByHeuristics(message) ?? guessedEncoding).GetString(message);
        }
        private static Encoding DetectUnicodeInByteSampleByHeuristics(byte[] SampleBytes)
        {
            long oddBinaryNullsInSample = 0;
            long evenBinaryNullsInSample = 0;
            long suspiciousUTF8SequenceCount = 0;
            long suspiciousUTF8BytesTotal = 0;
            long likelyUSASCIIBytesInSample = 0;
            // Cycle through, keeping count of binary null positions, possible UTF-8
            // sequences from upper ranges of Windows-1252, and probable US-ASCII
            // character counts.
            long currentPos = 0;
            int skipUTF8Bytes = 0;
            while (currentPos < SampleBytes.Length)
            {
                //binary null distribution
                if (SampleBytes[currentPos] == 0)
                {
                    if (currentPos % 2 == 0)
                        evenBinaryNullsInSample++;
                    else
                        oddBinaryNullsInSample++;
                }
                //likely US-ASCII characters
                if (IsCommonUSASCIIByte(SampleBytes[currentPos])) likelyUSASCIIBytesInSample++;
                //suspicious sequences (look like UTF-8)
                if (skipUTF8Bytes == 0)
                {
                    int lengthFound = DetectSuspiciousUTF8SequenceLength(SampleBytes, currentPos);
                    if (lengthFound > 0)
                    {
                        suspiciousUTF8SequenceCount++;
                        suspiciousUTF8BytesTotal += lengthFound;
                        skipUTF8Bytes = lengthFound - 1;
                    }
                }
                else
                {
                    skipUTF8Bytes--;
                }
                currentPos++;
            }
            //1: UTF-16 LE - in english / european environments, this is usually characterized by a
            // high proportion of odd binary nulls (starting at 0), with (as this is text) a low
            // proportion of even binary nulls.
            // The thresholds here used (less than 20% nulls where you expect non-nulls, and more than
            // 60% nulls where you do expect nulls) are completely arbitrary.
            if (((evenBinaryNullsInSample * 2.0) / SampleBytes.Length) < 0.2
            && ((oddBinaryNullsInSample * 2.0) / SampleBytes.Length) > 0.6
            )
                return Encoding.Unicode;
            //2: UTF-16 BE - in english / european environments, this is usually characterized by a
            // high proportion of even binary nulls (starting at 0), with (as this is text) a low
            // proportion of odd binary nulls.
            // The thresholds here used (less than 20% nulls where you expect non-nulls, and more than
            // 60% nulls where you do expect nulls) are completely arbitrary.
            if (((oddBinaryNullsInSample * 2.0) / SampleBytes.Length) < 0.2
            && ((evenBinaryNullsInSample * 2.0) / SampleBytes.Length) > 0.6
            )
                return Encoding.BigEndianUnicode;
            //3: UTF-8 - Martin Dürst outlines a method for detecting whether something CAN be UTF-8 content
            // using regexp, in his w3c.org unicode FAQ entry:
            // http://www.w3.org/International/questions/qa-forms-utf-8
            // adapted here for C#.
            string potentiallyMangledString = Encoding.ASCII.GetString(SampleBytes);
            Regex UTF8Validator = new Regex(@"\A("
            + @"[\x09\x0A\x0D\x20-\x7E]"
            + @"|[\xC2-\xDF][\x80-\xBF]"
            + @"|\xE0[\xA0-\xBF][\x80-\xBF]"
            + @"|[\xE1-\xEC\xEE\xEF][\x80-\xBF]{2}"
            + @"|\xED[\x80-\x9F][\x80-\xBF]"
            + @"|\xF0[\x90-\xBF][\x80-\xBF]{2}"
            + @"|[\xF1-\xF3][\x80-\xBF]{3}"
            + @"|\xF4[\x80-\x8F][\x80-\xBF]{2}"
            + @")*\z");
            if (UTF8Validator.IsMatch(potentiallyMangledString))
            {
                //Unfortunately, just the fact that it CAN be UTF-8 doesn't tell you much about probabilities.
                //If all the characters are in the 0-127 range, no harm done, most western charsets are same as UTF-8 in these ranges.
                //If some of the characters were in the upper range (western accented characters), however, they would likely be mangled to 2-byte by the UTF-8 encoding process.
                // So, we need to play stats.
                // The "Random" likelihood of any pair of randomly generated characters being one
                // of these "suspicious" character sequences is:
                // 128 / (256 * 256) = 0.2%.
                //
                // In western text data, that is SIGNIFICANTLY reduced - most text data stays in the <127
                // character range, so we assume that more than 1 in 500,000 of these character
                // sequences indicates UTF-8. The number 500,000 is completely arbitrary - so sue me.
                //
                // We can only assume these character sequences will be rare if we ALSO assume that this
                // IS in fact western text - in which case the bulk of the UTF-8 encoded data (that is
                // not already suspicious sequences) should be plain US-ASCII bytes. This, I
                // arbitrarily decided, should be 80% (a random distribution, eg binary data, would yield
                // approx 40%, so the chances of hitting this threshold by accident in random data are
                // VERY low).
                if ((suspiciousUTF8SequenceCount * 500000.0 / SampleBytes.Length >= 1) //suspicious sequences
                            && ( //all suspicious, so cannot evaluate proportion of US-Ascii
                                (SampleBytes.Length - suspiciousUTF8BytesTotal == 0)
                                    || likelyUSASCIIBytesInSample * 1.0 / (SampleBytes.Length - suspiciousUTF8BytesTotal) >= 0.8
                                )
                    )
                    return Encoding.UTF8;
            }
            return null;
        }
 
        private static bool IsCommonUSASCIIByte(byte testByte)
        {
            if (testByte == 0x0A //lf
            || testByte == 0x0D //cr
            || testByte == 0x09 //tab
            || (testByte >= 0x20 && testByte <= 0x2F) //common punctuation
            || (testByte >= 0x30 && testByte <= 0x39) //digits
            || (testByte >= 0x3A && testByte <= 0x40) //common punctuation
            || (testByte >= 0x41 && testByte <= 0x5A) //capital letters
            || (testByte >= 0x5B && testByte <= 0x60) //common punctuation
            || (testByte >= 0x61 && testByte <= 0x7A) //lowercase letters
            || (testByte >= 0x7B && testByte <= 0x7E) //common punctuation
            )
                return true;
            else
                return false;
        }
        private static int DetectSuspiciousUTF8SequenceLength(byte[] SampleBytes, long currentPos)
        {
            int lengthFound = 0;
            if (SampleBytes.Length >= currentPos + 1
            && SampleBytes[currentPos] == 0xC2
            )
            {
                if (SampleBytes[currentPos + 1] == 0x81
                || SampleBytes[currentPos + 1] == 0x8D
                || SampleBytes[currentPos + 1] == 0x8F
                )
                    lengthFound = 2;
                else if (SampleBytes[currentPos + 1] == 0x90
                || SampleBytes[currentPos + 1] == 0x9D
                )
                    lengthFound = 2;
                else if (SampleBytes[currentPos + 1] >= 0xA0
                && SampleBytes[currentPos + 1] <= 0xBF
                )
                    lengthFound = 2;
            }
            else if (SampleBytes.Length >= currentPos + 1
            && SampleBytes[currentPos] == 0xC3
            )
            {
                if (SampleBytes[currentPos + 1] >= 0x80
                && SampleBytes[currentPos + 1] <= 0xBF
                )
                    lengthFound = 2;
            }
            else if (SampleBytes.Length >= currentPos + 1
            && SampleBytes[currentPos] == 0xC5
            )
            {
                if (SampleBytes[currentPos + 1] == 0x92
                || SampleBytes[currentPos + 1] == 0x93
                )
                    lengthFound = 2;
                else if (SampleBytes[currentPos + 1] == 0xA0
                || SampleBytes[currentPos + 1] == 0xA1
                )
                    lengthFound = 2;
                else if (SampleBytes[currentPos + 1] == 0xB8
                || SampleBytes[currentPos + 1] == 0xBD
                || SampleBytes[currentPos + 1] == 0xBE
                )
                    lengthFound = 2;
            }
            else if (SampleBytes.Length >= currentPos + 1
            && SampleBytes[currentPos] == 0xC6
            )
            {
                if (SampleBytes[currentPos + 1] == 0x92)
                    lengthFound = 2;
            }
            else if (SampleBytes.Length >= currentPos + 1
            && SampleBytes[currentPos] == 0xCB
            )
            {
                if (SampleBytes[currentPos + 1] == 0x86
                || SampleBytes[currentPos + 1] == 0x9C
                )
                    lengthFound = 2;
            }
            else if (SampleBytes.Length >= currentPos + 2
            && SampleBytes[currentPos] == 0xE2
            )
            {
                if (SampleBytes[currentPos + 1] == 0x80)
                {
                    if (SampleBytes[currentPos + 2] == 0x93
                    || SampleBytes[currentPos + 2] == 0x94
                    )
                        lengthFound = 3;
                    if (SampleBytes[currentPos + 2] == 0x98
                    || SampleBytes[currentPos + 2] == 0x99
                    || SampleBytes[currentPos + 2] == 0x9A
                    )
                        lengthFound = 3;
                    if (SampleBytes[currentPos + 2] == 0x9C
                    || SampleBytes[currentPos + 2] == 0x9D
                    || SampleBytes[currentPos + 2] == 0x9E
                    )
                        lengthFound = 3;
                    if (SampleBytes[currentPos + 2] == 0xA0
                    || SampleBytes[currentPos + 2] == 0xA1
                    || SampleBytes[currentPos + 2] == 0xA2
                    )
                        lengthFound = 3;
                    if (SampleBytes[currentPos + 2] == 0xA6)
                        lengthFound = 3;
                    if (SampleBytes[currentPos + 2] == 0xB0)
                        lengthFound = 3;
                    if (SampleBytes[currentPos + 2] == 0xB9
                    || SampleBytes[currentPos + 2] == 0xBA
                    )
                        lengthFound = 3;
                }
                else if (SampleBytes[currentPos + 1] == 0x82
                && SampleBytes[currentPos + 2] == 0xAC
                )
                    lengthFound = 3;
                else if (SampleBytes[currentPos + 1] == 0x84
                && SampleBytes[currentPos + 2] == 0xA2
                )
                    lengthFound = 3;
            }
            return lengthFound;
        }
        #endregion
    }

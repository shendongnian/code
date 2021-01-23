    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Globalization;
    public class RtfNormalizer
    {
        public RtfNormalizer(string rtf)
        {
            if (rtf == null)
                throw new ArgumentNullException();
            Rtf = rtf;
        }
        public string Rtf { get; private set; }
        public string GetNormalizedString()
        {
            StringBuilder sb = new StringBuilder();
            var tokenizer = new RtfTokenizer(Rtf);
            RtfToken previous = RtfToken.None;
            while (tokenizer.MoveNext())
            {
                previous = AddCurrentToken(tokenizer, sb, previous);
            }
            return sb.ToString();
        }
        private RtfToken AddCurrentToken(RtfTokenizer tokenizer, StringBuilder sb, RtfToken previous)
        {
            var token = tokenizer.Current;
            switch (token.Type)
            {
                case RtfTokenType.None:
                    break;
                case RtfTokenType.StartGroup:
                    AddPushGroup(tokenizer, token, sb, previous);
                    break;
                case RtfTokenType.EndGroup:
                    AddPopGroup(tokenizer, token, sb, previous);
                    break;
                case RtfTokenType.ControlWord:
                    AddControlWord(tokenizer, token, sb, previous);
                    break;
                case RtfTokenType.ControlSymbol:
                    AddControlSymbol(tokenizer, token, sb, previous);
                    break;
                case RtfTokenType.IgnoredDelimiter:
                    AddIgnoredDelimiter(tokenizer, token, sb, previous);
                    break;
                case RtfTokenType.CRLF:
                    AddCarriageReturn(tokenizer, token, sb, previous);
                    break;
                case RtfTokenType.Content:
                    AddContent(tokenizer, token, sb, previous);
                    break;
                default:
                    Debug.Assert(false, "Unknown token type " + token.ToString());
                    break;
            }
            return token;
        }
        private void AddPushGroup(RtfTokenizer tokenizer, RtfToken token, StringBuilder sb, RtfToken previous)
        {
            AddContent(tokenizer, token, sb, previous);
        }
        private void AddPopGroup(RtfTokenizer tokenizer, RtfToken token, StringBuilder sb, RtfToken previous)
        {
            AddContent(tokenizer, token, sb, previous);
        }
        const string binPrefix = @"\bin";
        bool IsBinaryToken(RtfToken token, out int binaryLength)
        {
            // Rich Text Format (RTF) Specification, Version 1.9.1, p 209:
            //      Remember that binary data can occur when you’re skipping RTF.
            //      A simple way to skip a group in RTF is to keep a running count of the opening braces the RTF reader 
            //      has encountered in the RTF stream. When the RTF reader sees an opening brace, it increments the count. 
            //      When the reader sees a closing brace, it decrements the count. When the count becomes negative, the end 
            //      of the group was found. Unfortunately, this does not work when the RTF file contains a \binN control; the 
            //      reader must explicitly check each control word found to see if it is a \binN control, and if found, 
            //      skip that many bytes before resuming its scanning for braces.
            if (string.CompareOrdinal(binPrefix, 0, token.Rtf, token.StartIndex, binPrefix.Length) == 0)
            {
                if (RtfTokenizer.IsControlWordNumericParameter(token, token.StartIndex + binPrefix.Length))
                {
                    bool ok = int.TryParse(token.Rtf.Substring(token.StartIndex + binPrefix.Length, token.Length - binPrefix.Length),
                        NumberStyles.Integer, CultureInfo.InvariantCulture, 
                        out binaryLength);
                    return ok;
                }
            }
            binaryLength = -1;
            return false;
        }
        private void AddControlWord(RtfTokenizer tokenizer, RtfToken token, StringBuilder sb, RtfToken previous)
        {
            // Carriage return, usually ignored.
            // Rich Text Format (RTF) Specification, Version 1.9.1, p 151:
            // RTF writers should not use the carriage return/line feed (CR/LF) combination to break up pictures 
            // in binary format. If they do, the CR/LF combination is treated as literal text and considered part of the picture data.
            AddContent(tokenizer, token, sb, previous);
            int binaryLength;
            if (IsBinaryToken(token, out binaryLength))
            {
                if (tokenizer.MoveFixedLength(binaryLength))
                {
                    AddContent(tokenizer, tokenizer.Current, sb, previous);
                }
            }
        }
        private void AddControlSymbol(RtfTokenizer tokenizer, RtfToken token, StringBuilder sb, RtfToken previous)
        {
            AddContent(tokenizer, token, sb, previous);
        }
        private static bool? CanMergeToControlWord(RtfToken previous, RtfToken next)
        {
            if (previous.Type != RtfTokenType.ControlWord)
                throw new ArgumentException();
            if (next.Type == RtfTokenType.CRLF)
                return null; // Can't tell
            if (next.Type != RtfTokenType.Content)
                return false;
            if (previous.Length < 2)
                return false; // Internal error?
            if (next.Length < 1)
                return null; // Internal error?
            var lastCh = previous.Rtf[previous.StartIndex + previous.Length - 1];
            var nextCh = next.Rtf[next.StartIndex];
            if (RtfTokenizer.IsAsciiLetter(lastCh))
            {
                return RtfTokenizer.IsAsciiLetter(nextCh) || RtfTokenizer.IsAsciiMinus(nextCh) || RtfTokenizer.IsAsciiDigit(nextCh);
            }
            else if (RtfTokenizer.IsAsciiMinus(lastCh))
            {
                return RtfTokenizer.IsAsciiDigit(nextCh);
            }
            else if (RtfTokenizer.IsAsciiDigit(lastCh))
            {
                return RtfTokenizer.IsAsciiDigit(nextCh);
            }
            else
            {
                Debug.Assert(false, "unknown final character for control word token \"" + previous.ToString() + "\"");
                return false;
            }
        }
        bool IgnoredDelimiterIsRequired(RtfTokenizer tokenizer, RtfToken token, RtfToken previous)
        {
            // Word inserts required delimiters when required, and optional delimiters for beautification 
            // and readability.  Strip the optional delimiters while retaining the required ones.
            if (previous.Type != RtfTokenType.ControlWord)
                return false;
            var current = tokenizer.Current;
            try
            {
                while (tokenizer.MoveNext())
                {
                    var next = tokenizer.Current;
                    var canMerge = CanMergeToControlWord(previous, next);
                    if (canMerge == null)
                        continue;
                    return canMerge.Value;
                }
            }
            finally
            {
                tokenizer.MoveTo(current);
            }
            return false;
        }
        private void AddIgnoredDelimiter(RtfTokenizer tokenizer, RtfToken token, StringBuilder sb, RtfToken previous)
        {
            // Rich Text Format (RTF) Specification, Version 1.9.1, p 151:
            // an RTF file does not have to contain any carriage return/line feed pairs (CRLFs) and CRLFs should be ignored by RTF readers except that 
            // they can act as control word delimiters. RTF files are more readable when CRLFs occur at major group boundaries.
            //
            // but then later:
            // 
            // If a single space delimits the control word, the space does not appear in the document (it’s ignored). Any characters following the single space delimiter, including any subsequent spaces, 
            // will appear as text or spaces in the document. For this reason, you should use spaces only where necessary. It is recommended to avoid spaces as a means of breaking up RTF syntax to make 
            // it easier to read. You can use paragraph marks (CR, LF, or CRLF) to break up lines without changing the meaning except in destinations that contain \binN. 
            // In this document, a control word that takes a numeric parameter N is written with the N, as shown here for \binN, unless the control word appears with an explicit value. The only exceptions to 
            // this are “toggle” control words like \b (bold toggle), which have only two states. When such a control word has no parameter or has a nonzero parameter, the control word turns the property on. 
            // When such a control word has a parameter of 0, the control word turns the property off. For example, \b turns on bold and \b0 turns off bold. In the definitions of these toggle control words, 
            // the control word names are followed by an asterisk.
            if (IgnoredDelimiterIsRequired(tokenizer, token, previous))
                // There *May* be a need for a delimiter, 
                AddContent(tokenizer, " ", sb, previous);
        }
        private void AddCarriageReturn(RtfTokenizer tokenizer, RtfToken token, StringBuilder sb, RtfToken previous)
        {
            // DO NOTHING.
        }
        private void AddContent(RtfTokenizer tokenizer, RtfToken token, StringBuilder sb, RtfToken previous)
        {
            sb.Append(token.ToString());
        }
        private void AddContent(RtfTokenizer tokenizer, string content, StringBuilder sb, RtfToken previous)
        {
            sb.Append(content);
        }
    }

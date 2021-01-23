    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    public enum RtfTokenType
    {
        None = 0,
        StartGroup,
        EndGroup,
        CRLF,
        ControlWord,
        ControlSymbol,
        IgnoredDelimiter,
        Content,
    }
    public struct RtfToken : IEquatable<RtfToken>
    {
        public static RtfToken None { get { return new RtfToken(); } }
        public RtfToken(RtfTokenType type, int startIndex, int length, string rtf)
            : this()
        {
            this.Type = type;
            this.StartIndex = startIndex;
            this.Length = length;
            this.Rtf = rtf;
        }
        public RtfTokenType Type { get; private set; }
        public int StartIndex { get; private set; }
        public int Length { get; private set; }
        
        public string Rtf { get; private set; }
        public bool IsEmpty { get { return Rtf == null; } }
        #region IEquatable<RtfToken> Members
        public bool Equals(RtfToken other)
        {
            if (this.Type != other.Type)
                return false;
            if (this.Length != other.Length)
                return false;
            if (this.IsEmpty)
                return other.IsEmpty;
            else 
                return string.CompareOrdinal(this.Rtf, StartIndex, other.Rtf, other.StartIndex, Length) == 0;
        }
        public static bool operator ==(RtfToken first, RtfToken second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(RtfToken first, RtfToken second)
        {
            return !first.Equals(second);
        }
        #endregion
        public override string ToString()
        {
            if (Rtf == null)
                return string.Empty;
            return Rtf.Substring(StartIndex, Length);
        }
        public override bool Equals(object obj)
        {
            if (obj is RtfToken)
                return Equals((RtfToken)obj);
            return false;
        }
        public override int GetHashCode()
        {
            if (Rtf == null)
                return 0;
            int code = Type.GetHashCode() ^ Length.GetHashCode();
            for (int i = StartIndex; i < Length; i++)
                code ^= Rtf[i].GetHashCode();
            return code;
        }
    }
    public class RtfTokenizer : IEnumerator<RtfToken> 
    {
        public RtfTokenizer(string rtf)
        {
            if (rtf == null)
                throw new ArgumentNullException();
            Rtf = rtf;
        }
        public string Rtf { get; private set; }
    #if false
        Rich Text Format (RTF) Specification, Version 1.9.1:
        Control Word
        An RTF control word is a specially formatted command used to mark characters for display on a monitor or characters destined for a printer. A control word’s name cannot be longer than 32 letters. 
        A control word is defined by:
        \<ASCII Letter Sequence><Delimiter>
        where <Delimiter> marks the end of the control word’s name. For example:
        \par
        A backslash begins each control word and the control word is case sensitive.
        The <ASCII Letter Sequence> is made up of ASCII alphabetical characters (a through z and A through Z). Control words (also known as keywords) originally did not contain any uppercase characters, however in recent years uppercase characters appear in some newer control words.
        The <Delimiter> can be one of the following:
        •	A space. This serves only to delimit a control word and is ignored in subsequent processing.
        •	A numeric digit or an ASCII minus sign (-), which indicates that a numeric parameter is associated with the control word. The subsequent digital sequence is then delimited by any character other than an ASCII digit (commonly another control word that begins with a backslash). The parameter can be a positive or negative decimal number. The range of the values for the number is nominally –32768 through 32767, i.e., a signed 16-bit integer. A small number of control words take values in the range −2,147,483,648 to 2,147,483,647 (32-bit signed integer). These control words include \binN, \revdttmN, \rsidN related control words and some picture properties like \bliptagN. Here N stands for the numeric parameter. An RTF parser must allow for up to 10 digits optionally preceded by a minus sign. If the delimiter is a space, it is discarded, that is, it’s not included in subsequent processing.
        •	Any character other than a letter or a digit. In this case, the delimiting character terminates the control word and is not part of the control word. Such as a backslash “\”, which means a new control word or a control symbol follows.
        If a single space delimits the control word, the space does not appear in the document (it’s ignored). Any characters following the single space delimiter, including any subsequent spaces, will appear as text or spaces in the document. For this reason, you should use spaces only where necessary. It is recommended to avoid spaces as a means of breaking up RTF syntax to make it easier to read. You can use paragraph marks (CR, LF, or CRLF) to break up lines without changing the meaning except in destinations that contain \binN. 
        In this document, a control word that takes a numeric parameter N is written with the N, as shown here for \binN, unless the control word appears with an explicit value. The only exceptions to this are “toggle” control words like \b (bold toggle), which have only two states. When such a control word has no parameter or has a nonzero parameter, the control word turns the property on. When such a control word has a parameter of 0, the control word turns the property off. For example, \b turns on bold and \b0 turns off bold. In the definitions of these toggle control words, the control word names are followed by an asterisk.
    #endif
        public static bool IsAsciiLetter(char ch)
        {
            if (ch >= 'a' && ch <= 'z')
                return true;
            if (ch >= 'A' && ch <= 'Z')
                return true;
            return false;
        }
        public static bool IsAsciiDigit(char ch)
        {
            if (ch >= '0' && ch <= '9')
                return true;
            return false;
        }
        public static bool IsAsciiMinus(char ch)
        {
            return ch == '-';
        }
        public static bool IsControlWordNumericParameter(RtfToken token, int startIndex)
        {
            int inLength = token.Length - startIndex;
            int actualLength;
            if (IsControlWordNumericParameter(token.Rtf, token.StartIndex + startIndex, out actualLength)
                && actualLength == inLength)
            {
                return true;
            }
            return false;
        }
        static bool IsControlWordNumericParameter(string rtf, int startIndex, out int length)
        {
            int index = startIndex;
            if (index < rtf.Length - 1 && IsAsciiMinus(rtf[index]) && IsAsciiDigit(rtf[index + 1]))
                index++;
            for (; index < rtf.Length && IsAsciiDigit(rtf[index]); index++)
                ;
            length = index - startIndex;
            return length > 0;
        }
        static bool IsControlWord(string rtf, int startIndex, out int length)
        {
            int index = startIndex;
            for (; index < rtf.Length && IsAsciiLetter(rtf[index]); index++)
                ;
            length = index - startIndex;
            if (length == 0)
                return false;
            int paramLength;
            if (IsControlWordNumericParameter(rtf, index, out paramLength))
                length += paramLength;
            return true;
        }
        public IEnumerable<RtfToken> AsEnumerable()
        {
            int oldPos = nextPosition;
            RtfToken oldCurrent = current;
            try
            {
                while (MoveNext())
                    yield return Current;
            }
            finally
            {
                nextPosition = oldPos;
                current = oldCurrent;
            }
        }
        string RebuildRtf()
        {
            string newRtf = AsEnumerable().Aggregate(new StringBuilder(), (sb, t) => sb.Append(t.ToString())).ToString();
            return newRtf;
        }
        [Conditional("DEBUG")]
        public void AssertValid()
        {
            var newRtf = RebuildRtf();
            if (Rtf != newRtf)
            {
                Debug.Assert(false, "rebuilt rtf mismatch");
            }
        }
        #region IEnumerator<RtfToken> Members
        int nextPosition = 0;
        RtfToken current = new RtfToken();
        public RtfToken Current
        {
            get {
                return current;
            }
        }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
        }
        #endregion
        #region IEnumerator Members
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        public void MoveTo(RtfToken token)
        {
            if (token.Rtf != Rtf)
                throw new ArgumentException();
            nextPosition = token.StartIndex + token.Length;
            current = token;
        }
        public bool MoveFixedLength(int length)
        {
            if (nextPosition >= Rtf.Length)
                return false;
            int actualLength = Math.Min(length, Rtf.Length - nextPosition);
            current = new RtfToken(RtfTokenType.Content, nextPosition, actualLength, Rtf);
            nextPosition += actualLength;
            return true;
        }
        static string crlf = "\r\n";
        static bool IsCRLF(string rtf, int startIndex)
        {
            return string.CompareOrdinal(crlf, 0, rtf, startIndex, crlf.Length) == 0;
        }
        public bool MoveNext()
        {
            // As previously mentioned, the backslash (\) and braces ({ }) have special meaning in RTF. To use these characters as text, precede them with a backslash, as in the control symbols \\, \{, and \}.
            if (nextPosition >= Rtf.Length)
                return false;
            RtfToken next = new RtfToken();
            if (Rtf[nextPosition] == '{')
            {
                next = new RtfToken(RtfTokenType.StartGroup, nextPosition, 1, Rtf);
            }
            else if (Rtf[nextPosition] == '}')
            {
                // End group
                next = new RtfToken(RtfTokenType.EndGroup, nextPosition, 1, Rtf);
            }
            else if (IsCRLF(Rtf, nextPosition))
            {
                if (current.Type == RtfTokenType.ControlWord)
                    next = new RtfToken(RtfTokenType.IgnoredDelimiter, nextPosition, crlf.Length, Rtf);
                else
                    next = new RtfToken(RtfTokenType.CRLF, nextPosition, crlf.Length, Rtf);
            }
            else if (Rtf[nextPosition] == ' ')
            {
                if (current.Type == RtfTokenType.ControlWord)
                    next = new RtfToken(RtfTokenType.IgnoredDelimiter, nextPosition, 1, Rtf);
                else
                    next = new RtfToken(RtfTokenType.Content, nextPosition, 1, Rtf);
            }
            else if (Rtf[nextPosition] == '\\')
            {
                if (nextPosition == Rtf.Length - 1)
                    next = new RtfToken(RtfTokenType.Content, nextPosition, 1, Rtf); // Junk file?
                else
                {
                    int length;
                    if (IsControlWord(Rtf, nextPosition + 1, out length))
                    {
                        next = new RtfToken(RtfTokenType.ControlWord, nextPosition, length + 1, Rtf);
                    }
                    else
                    {
                        // Control symbol.
                        next = new RtfToken(RtfTokenType.ControlSymbol, nextPosition, 2, Rtf);
                    }
                }
            }
            else
            {
                // Content
                next = new RtfToken(RtfTokenType.Content, nextPosition, 1, Rtf);
            }
            if (next.Length == 0)
                throw new Exception("internal error");
            current = next;
            nextPosition = next.StartIndex + next.Length;
            return true;
        }
        public void Reset()
        {
            nextPosition = 0;
        }
        #endregion
    }

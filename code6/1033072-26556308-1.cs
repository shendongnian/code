    /// <summary>
    /// Non-nullable string.
    /// </summary>
    public struct nString
    {
        public nString(string value)
            : this()
        {
            Value = value ?? "";
        }
        public nString(char[] value)
        {
            Value = new string(value) ?? "";
        }
        public nString(char c, int count)
        {
            Value = new string(c, count) ?? "";
        }
        public nString(char[] value, int startIndex, int length)
        {
            Value = new string(value, startIndex, length) ?? "";
        }
        public string Value
        {
            get;
            private set;
        }
        public static implicit operator nString(string value)
        {
            return new nString(value);
        }
        public static implicit operator string(nString value)
        {
            return value.Value ?? "";
        }
        public int CompareTo(string strB)
        {
            Value = Value ?? "";
            return Value.CompareTo(strB);
        }
        public bool Contains(string value)
        {
            Value = Value ?? "";
            return Value.Contains(value);
        }
        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            Value = Value ?? "";
            Value.CopyTo(sourceIndex, destination, destinationIndex, count);
        }
        public bool EndsWith(string value)
        {
            Value = Value ?? "";
            return Value.EndsWith(value);
        }
        public bool EndsWith(string value, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.EndsWith(value, comparisonType);
        }
        public override bool Equals(object obj)
        {
            Value = Value ?? "";
            return Value.Equals(obj);
        }
        public bool Equals(string value)
        {
            Value = Value ?? "";
            return Value.Equals(value);
        }
        public bool Equals(string value, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.Equals(value, comparisonType);
        }
        public override int GetHashCode()
        {
            Value = Value ?? "";
            return Value.GetHashCode();
        }
        public new Type GetType()
        {
            return typeof(string);
        }
        public int IndexOf(char value)
        {
            Value = Value ?? "";
            return Value.IndexOf(value);
        }
        public int IndexOf(string value)
        {
            Value = Value ?? "";
            return Value.IndexOf(value);
        }
        public int IndexOf(char value, int startIndex)
        {
            Value = Value ?? "";
            return Value.IndexOf(value, startIndex);
        }
        public int IndexOf(string value, int startIndex)
        {
            Value = Value ?? "";
            return Value.IndexOf(value, startIndex);
        }
        public int IndexOf(string value, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.IndexOf(value, comparisonType);
        }
        public int IndexOf(char value, int startIndex, int count)
        {
            Value = Value ?? "";
            return Value.IndexOf(value, startIndex, count);
        }
        public int IndexOf(string value, int startIndex, int count)
        {
            Value = Value ?? "";
            return Value.IndexOf(value, startIndex, count);
        }
        public int IndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.IndexOf(value, startIndex, comparisonType);
        }
        public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.IndexOf(value, startIndex, count, comparisonType);
        }
        public int IndexOfAny(char[] anyOf)
        {
            Value = Value ?? "";
            return Value.IndexOfAny(anyOf);
        }
        public int IndexOfAny(char[] anyOf, int startIndex)
        {
            Value = Value ?? "";
            return Value.IndexOfAny(anyOf, startIndex);
        }
        public int IndexOfAny(char[] anyOf, int startIndex, int count)
        {
            Value = Value ?? "";
            return Value.IndexOfAny(anyOf, startIndex, count);
        }
        public string Insert(int startIndex, string value)
        {
            Value = Value ?? "";
            return Value.Insert(startIndex, value);
        }
        public int LastIndexOf(char value)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value);
        }
        public int LastIndexOf(string value)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value);
        }
        public int LastIndexOf(char value, int startIndex)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value, startIndex);
        }
        public int LastIndexOf(string value, int startIndex)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value, startIndex);
        }
        public int LastIndexOf(string value, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value, comparisonType);
        }
        public int LastIndexOf(char value, int startIndex, int count)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value, startIndex, count);
        }
        public int LastIndexOf(string value, int startIndex, int count)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value, startIndex, count);
        }
        public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value, startIndex, comparisonType);
        }
        public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.LastIndexOf(value, startIndex, count, comparisonType);
        }
        public int LastIndexOfAny(char[] anyOf)
        {
            Value = Value ?? "";
            return Value.LastIndexOfAny(anyOf);
        }
        public int LastIndexOfAny(char[] anyOf, int startIndex)
        {
            Value = Value ?? "";
            return Value.LastIndexOfAny(anyOf, startIndex);
        }
        public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
        {
            Value = Value ?? "";
            return Value.LastIndexOfAny(anyOf, startIndex, count);
        }
        public int Length
        {
            get
            {
                Value = Value ?? "";
                return Value.Length;
            }
        }
        public string PadLeft(int totalWidth)
        {
            Value = Value ?? "";
            return Value.PadLeft(totalWidth);
        }
        public string PadLeft(int totalWidth, char paddingChar)
        {
            Value = Value ?? "";
            return Value.PadLeft(totalWidth, paddingChar);
        }
        public string PadRight(int totalWidth)
        {
            Value = Value ?? "";
            return Value.PadRight(totalWidth);
        }
        public string PadRight(int totalWidth, char paddingChar)
        {
            Value = Value ?? "";
            return Value.PadRight(totalWidth, paddingChar);
        }
        public string Remove(int startIndex)
        {
            Value = Value ?? "";
            return Value.Remove(startIndex);
        }
        public string Remove(int startIndex, int count)
        {
            Value = Value ?? "";
            return Value.Remove(startIndex, count);
        }
        public string Replace(char oldChar, char newChar)
        {
            Value = Value ?? "";
            return Value.Replace(oldChar, newChar);
        }
        public string Replace(string oldValue, string newValue)
        {
            Value = Value ?? "";
            return Value.Replace(oldValue, newValue);
        }
        public string[] Split(params char[] separator)
        {
            Value = Value ?? "";
            return Value.Split(separator);
        }
        public string[] Split(char[] separator, StringSplitOptions options)
        {
            Value = Value ?? "";
            return Value.Split(separator, options);
        }
        public string[] Split(string[] separator, StringSplitOptions options)
        {
            Value = Value ?? "";
            return Value.Split(separator, options);
        }
        public bool StartsWith(string value)
        {
            Value = Value ?? "";
            return Value.StartsWith(value);
        }
        public bool StartsWith(string value, StringComparison comparisonType)
        {
            Value = Value ?? "";
            return Value.StartsWith(value, comparisonType);
        }
        public string Substring(int startIndex)
        {
            Value = Value ?? "";
            return Value.Substring(startIndex);
        }
        public string Substring(int startIndex, int length)
        {
            Value = Value ?? "";
            return Value.Substring(startIndex, length);
        }
        public char[] ToCharArray()
        {
            Value = Value ?? "";
            return Value.ToCharArray();
        }
        public string ToLower()
        {
            Value = Value ?? "";
            return Value.ToLower();
        }
        public string ToLowerInvariant()
        {
            Value = Value ?? "";
            return Value.ToLowerInvariant();
        }
        public override string ToString()
        {
            Value = Value ?? "";
            return Value.ToString();
        }
        public string ToUpper()
        {
            Value = Value ?? "";
            return Value.ToUpper();
        }
        public string ToUpperInvariant()
        {
            Value = Value ?? "";
            return Value.ToUpperInvariant();
        }
        public string Trim()
        {
            Value = Value ?? "";
            return Value.Trim();
        }
        public string Trim(params char[] trimChars)
        {
            Value = Value ?? "";
            return Value.Trim(trimChars);
        }
        public string TrimEnd(params char[] trimChars)
        {
            Value = Value ?? "";
            return Value.TrimEnd(trimChars);
        }
        public string TrimStart(params char[] trimChars)
        {
            Value = Value ?? "";
            return Value.TrimStart(trimChars);
        }
    }

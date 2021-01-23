    public class AlphaNumericComparer : IComparer<string>
        {
            public int Compare(string lhs, string rhs)
            {
                if (lhs == null)
                {
                    return 0;
                }
    
                if (rhs == null)
                {
                    return 0;
                }
    
                var s1Length = lhs.Length;
                var s2Length = rhs.Length;
                var s1Marker = 0;
                var s2Marker = 0;
    
                // Walk through two the strings with two markers.
                while (s1Marker < s1Length && s2Marker < s2Length)
                { 
                    var ch1 = lhs[s1Marker];
                    var ch2 = rhs[s2Marker];
    
                    var s1Buffer = new char[s1Length];
                    var loc1 = 0;
                    var s2Buffer = new char[s2Length];
                    var loc2 = 0;
    
                    // Walk through all following characters that are digits or
                    // characters in BOTH strings starting at the appropriate marker.
                    // Collect char arrays.
                    do
                    {
                        s1Buffer[loc1++] = ch1;
                        s1Marker++;
    
                        if (s1Marker < s1Length)
                        {
                            ch1 = lhs[s1Marker];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch1) == char.IsDigit(s1Buffer[0]));
    
                    do
                    {
                        s2Buffer[loc2++] = ch2;
                        s2Marker++;
    
                        if (s2Marker < s2Length)
                        {
                            ch2 = rhs[s2Marker];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch2) == char.IsDigit(s2Buffer[0]));
    
                    // If we have collected numbers, compare them numerically.
                    // Otherwise, if we have strings, compare them alphabetically.
                    string str1 = new string(s1Buffer);
                    string str2 = new string(s2Buffer);
    
                    int result;
    
                    if (char.IsDigit(s1Buffer[0]) && char.IsDigit(s2Buffer[0]))
                    {
                        var thisNumericChunk = int.Parse(str1);
                        var thatNumericChunk = int.Parse(str2);
                        result = thisNumericChunk.CompareTo(thatNumericChunk);
                    }
                    else
                    {
                        result = str1.CompareTo(str2);
                    }
    
                    if (result != 0)
                    {
                        return result;
                    }
                }
                return s1Length - s2Length;
            }
        }

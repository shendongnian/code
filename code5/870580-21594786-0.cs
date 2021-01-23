        int NextGraphemeIndex(string s, int index)
        {
            for (++index; index != s.Length; ++index)
            {
                uint ch = s[index];
                int characterEndIndex = index;
                if (Windows.Data.Text.UnicodeCharacters.IsHighSurrogate(ch))
                {
                    ++characterEndIndex;
                    ch = Windows.Data.Text.UnicodeCharacters.GetCodepointFromSurrogatePair(ch, s[characterEndIndex]);
                }
                if (Windows.Data.Text.UnicodeCharacters.IsGraphemeBase(ch))
                {
                    break;
                }
                index = characterEndIndex;
            }
            return index;
        }

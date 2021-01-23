        private static List<int> FindAllDoublePositions(string text)
        {
            List<int> positions = new List<int>();
            char[] ca = text.ToCharArray();
            char lastChar = (char)0;
            for (int pos = 0; pos < ca.Length; pos++)
            {
                if (Char.IsNumber(ca[pos]) && lastChar == ca[pos])
                    positions.Add(pos);
                lastChar = ca[pos];
            }
            return positions;
        }

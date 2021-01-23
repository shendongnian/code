    struct Led
    {
        public readonly bool Strip;
        public readonly byte Position;
        public readonly byte Red;
        public readonly byte Green;
        public readonly byte Blue;
        public Led(bool strip, byte pos, byte r, byte g, byte b)
        {
            // set private fields
        }
        public int ToInt()
        {
            const int StripBit = 0x01000000;
            const int PositionMask = 0x3F; // 6 bits
            // bits 21 through 26
            const int PositionShift = 20;
            const int ColorMask = 0x7F;
            const int RedShift = 14;
            const int GreenShift = 7;
            int val = Strip ? 0 : StripBit;
            val = val | ((Position & PositionMask) << PositionShift);
            val = val | ((Red & ColorMask) << RedShift);
            val = val | (Blue & ColorMask);
            return val;
        }
    }

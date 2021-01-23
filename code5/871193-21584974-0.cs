        public static string ConvertIntToBinary2(int number)
        {
            var bits = (sizeof(int) * 8); // 8bits per byte
            StringBuilder sb = new StringBuilder();
            var mask = (uint)(1 << bits-1);
            bool ignore = true;
            for (int i = 0; i < bits; i++)
            {
                var bit = (number & mask) == mask;
                if (bit)
                    ignore = false;
                if (!ignore)
                    sb.Append(bit ? '1' : '0');
                mask = mask >> 1;
            }
            return sb.ToString();
        }

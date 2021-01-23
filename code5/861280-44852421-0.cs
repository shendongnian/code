            byte[] b = new byte[] { 10, 12, 12, 12 };
            DateTime now = DateTime.Now;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var csMinDate = DateTime.MinValue;
            TimeSpan tsEpoch = now - epoch;
            int passedSecods = (int)tsEpoch.TotalSeconds;
            byte[] copyBytes = BitConverter.GetBytes(passedSecods);
            Array.Copy(copyBytes, 0, b, 0, 4);
            DateTime tCompare = epoch.AddSeconds(BitConverter.ToInt32(b, 0));

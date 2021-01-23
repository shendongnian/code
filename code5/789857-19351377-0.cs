            IList<byte> retValue = null;
            if (!string.IsNullOrEmpty(str) && str.Length == 16)
            {
                MemoryStream s_stream;
                using (s_stream = new MemoryStream(Encoding.ASCII.GetBytes(str)))
                {
                    using (var br = new BinaryReader(s_stream))
                    {
                        retValue = new List<byte>();
                        while (s_stream.Position < s_stream.Length)
                        {
                            retValue.Add(byte.Parse(Encoding.ASCII.GetString(br.ReadBytes(2)),
                                System.Globalization.NumberStyles.HexNumber));
                        }
                    }
                }
            }
            return retValue.ToArray();
        }

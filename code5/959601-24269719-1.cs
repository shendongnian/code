        public static class BinaryFile
        {
            private static Dictionary<byte, string> __byteLookup = new Dictionary<byte, string>();
            static BinaryFile()
            {
                // Display printable ASCII characters as-is
                for (byte i = 0x20; i < 0x7F; i++) { __byteLookup[i] = ((char)i).ToString(); }
                // Display non-printable ASCII characters as \{byte value}
                for (byte i = 0; i < 0x20; i++) { __byteLookup[i] = "\\" + i.ToString();}
                for (int i = 0x7F; i <= 0xFF; i++) { __byteLookup[(byte)i] = "\\" + i.ToString(); }
                // Replace pre-populated values with custom values here if desired.
            }
            public static string ReadString(string filename)
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filename);
                return String.Join("", (from i in fileBytes select __byteLookup[i]).ToArray());
            }
        }

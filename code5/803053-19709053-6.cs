    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace OleImageTest
    {
        public static class OleImageUnwrap
        {
            public static byte[] GetImageBytesFromOLEField(byte[] oleFieldBytes)
            {
                // adapted from http://blogs.msdn.com/b/pranab/archive/2008/07/15/removing-ole-header-from-images-stored-in-ms-access-db-as-ole-object.aspx
    
                const int maxNumberOfBytesToSearch = 10000;
                byte[] imageBytes;  // return value
    
                var imageSignatures = new List<byte[]>();
                // PNG_ID_BLOCK = "\x89PNG\r\n\x1a\n"
                imageSignatures.Add(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A });
                // JPG_ID_BLOCK = "\xFF\xD8\xFF"
                imageSignatures.Add(new byte[] { 0xFF, 0xD8, 0xFF });
                // GIF_ID_BLOCK = "GIF8"
                imageSignatures.Add(new byte[] { 0x47, 0x49, 0x46, 0x38 });
                // TIFF_ID_BLOCK = "II*\x00"
                imageSignatures.Add(new byte[] { 0x49, 0x49, 0x2A, 0x00 });
                // BITMAP_ID_BLOCK = "BM"
                imageSignatures.Add(new byte[] { 0x42, 0x4D });
    
                int numberOfBytesToSearch = (oleFieldBytes.Count() < maxNumberOfBytesToSearch ? oleFieldBytes.Count() : maxNumberOfBytesToSearch);
                var startingBytes = new byte[numberOfBytesToSearch];
                Array.Copy(oleFieldBytes, startingBytes, numberOfBytesToSearch);
    
                var positions = new List<int>();
                foreach (byte[] blockSignature in imageSignatures)
                {
                    positions = startingBytes.IndexOfSequence(blockSignature, 0);
                    if (positions.Count > 0)
                    {
                        break;
                    }
                }
                int iPos = -1;
                if (positions.Count > 0)
                {
                    iPos = positions[0];
                }
    
                if (iPos == -1)
                    throw new Exception("Unable to determine header size for the OLE Object");
    
                imageBytes = new byte[oleFieldBytes.LongLength - iPos];
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms.Write(oleFieldBytes, iPos, oleFieldBytes.Length - iPos);
                imageBytes = ms.ToArray();
                ms.Close();
                ms.Dispose();
                return imageBytes;
            }
    
            private static List<int> IndexOfSequence(this byte[] buffer, byte[] pattern, int startIndex)
            {
                // ref: http://stackoverflow.com/a/332667/2144390
                List<int> positions = new List<int>();
                int i = Array.IndexOf<byte>(buffer, pattern[0], startIndex);
                while (i >= 0 && i <= buffer.Length - pattern.Length)
                {
                    byte[] segment = new byte[pattern.Length];
                    Buffer.BlockCopy(buffer, i, segment, 0, pattern.Length);
                    if (segment.SequenceEqual<byte>(pattern))
                        positions.Add(i);
                    i = Array.IndexOf<byte>(buffer, pattern[0], i + 1);
                }
                return positions;
            }
        }
    }

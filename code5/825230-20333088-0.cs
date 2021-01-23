                    // Split the 16 byte MAC key into two keys
                byte[] key1 = new byte[8];
                Array.Copy(kMAC, 0, key1, 0, 8);
                byte[] key2 = new byte[8];
                Array.Copy(kMAC, 8, key2, 0, 8);
                Console.WriteLine("key1:{0}", Hex.BytesToSpacedHexString(key1));
                Console.WriteLine("key2:{0}", Hex.BytesToSpacedHexString(key2));
                // Padd the data with Padding Method 2 (Bit Padding)
                System.IO.MemoryStream out_Renamed = new System.IO.MemoryStream();
                out_Renamed.Write(eIfd, 0, eIfd.Length);
                out_Renamed.WriteByte((byte)(0x80));
                while (out_Renamed.Length % 8 != 0)
                {
                    out_Renamed.WriteByte((byte)0x00);
                }
                byte[] eIfd_padded = out_Renamed.ToArray();
                Console.WriteLine("eIfd_padded:{0}", Hex.BytesToSpacedHexString(eIfd_padded));
                // Split the blocks
                byte[] d1 = new byte[8];
                byte[] d2 = new byte[8];
                byte[] d3 = new byte[8];
                byte[] d4 = new byte[8];
                byte[] d5 = new byte[8];
                Array.Copy(eIfd_padded, 0, d1, 0, 8);
                Array.Copy(eIfd_padded, 8, d2, 0, 8);
                Array.Copy(eIfd_padded, 16, d3, 0, 8);
                Array.Copy(eIfd_padded, 24, d4, 0, 8);
                Array.Copy(eIfd_padded, 32, d5, 0, 8);
                DES des1 = DES.Create();
                des1.BlockSize = 64;
                des1.Key = key1;
                des1.Mode = CipherMode.CBC;
                des1.Padding = PaddingMode.None;
                des1.IV = new byte[8];
                DES des2 = DES.Create();
                des2.BlockSize = 64;
                des2.Key = key2;
                des2.Mode = CipherMode.CBC;
                des2.Padding = PaddingMode.None;
                des2.IV = new byte[8];
                // MAC Algorithm 3
                // Initial Transformation 1
                byte[] h1 = des1.CreateEncryptor().TransformFinalBlock(d1, 0, 8);
                // Iteration on the rest of blocks
                // XOR
                byte[] int2 = new byte[8];
                for (int i = 0; i < 8; i++)
                    int2[i] = (byte)(h1[i] ^ d2[i]);
                // Encrypt
                byte[] h2 = des1.CreateEncryptor().TransformFinalBlock(int2, 0, 8);
                // XOR
                byte[] int3 = new byte[8];
                for (int i = 0; i < 8; i++)
                    int3[i] = (byte)(h2[i] ^ d3[i]);
                // Encrypt
                byte[] h3 = des1.CreateEncryptor().TransformFinalBlock(int3, 0, 8);
                // XOR
                byte[] int4 = new byte[8];
                for (int i = 0; i < 8; i++)
                    int4[i] = (byte)(h3[i] ^ d4[i]);
                // Encrypt
                byte[] h4 = des1.CreateEncryptor().TransformFinalBlock(int4, 0, 8);
                // XOR
                byte[] int5 = new byte[8];
                for (int i = 0; i < 8; i++)
                    int5[i] = (byte)(h4[i] ^ d5[i]);
                // Encrypt
                byte[] h5 = des1.CreateEncryptor().TransformFinalBlock(int5, 0, 8);
                // Output Transformation 3
                byte[] h5decrypt = des2.CreateDecryptor().TransformFinalBlock(h5, 0, 8);
                byte[] mIfd = des1.CreateEncryptor().TransformFinalBlock(h5decrypt, 0, 8);
                Console.WriteLine("mIFD:{0}", Hex.BytesToSpacedHexString(mIfd));

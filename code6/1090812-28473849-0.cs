    public override void GenerateIV() {
                Contract.Ensures(IVValue != null && IVValue.Length == BlockSizeValue / 8);
                Contract.Assert(m_cspHandle != null);
                Contract.Assert(BlockSizeValue % 8 == 0);
     
                byte[] iv = new byte[BlockSizeValue / 8];
                if (!CapiNative.UnsafeNativeMethods.CryptGenRandom(m_cspHandle, iv.Length, iv)) {
                    throw new CryptographicException(Marshal.GetLastWin32Error());
                }
     
                IVValue = iv;
            }

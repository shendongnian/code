    IntPtr passwordBytes = Marshal.SecureStringToCoTaskMemUnicode(password);
            try
            {
                unsafe
                {
                    byte* byteArrayStart = (byte*)passwordBytes.ToPointer();
                    
                    int length = password.Length;
                     byte[] encrypted = new byte[length];
                    for (int i = 0; i < length; ++i)
                    {
                        encrypted[i] =  EncryptByte(*(byteArrayStart + i));
                    }
                }
            }
            finally
            {
                // This removed the decrypted data bytes from memory as soon as we finished encrypting bytes. Thus reducing the window that any one can access the secure password
                Marshal.ZeroFreeGlobalAllocAnsi(passwordBytes);
            }

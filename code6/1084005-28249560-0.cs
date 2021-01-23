    public static class SecureStringHelpers
    {
        public static void WriteSecureStringToResponse(this HtmlHelper helper, SecureString secureString)
        {
            if (secureString != null)
            {
                IntPtr unmanagedString = IntPtr.Zero;
                var secureByteArray = new byte[2];
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                    var offset = 0;
                    var endOfString = false;
                    do
                    {
                        secureByteArray[0] = Marshal.ReadByte(unmanagedString, offset);
                        offset++;
                        secureByteArray[1] = Marshal.ReadByte(unmanagedString, offset);
                        offset++;
                        if (!(secureByteArray[0] == 0 && secureByteArray[1] == 0))
                        {
                            helper.ViewContext.Writer.Write(System.BitConverter.ToChar(secureByteArray, 0));
                        }
                        else
                        {
                            endOfString = true;
                        }
                    } while (!endOfString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                    secureByteArray[0] = 0;
                    secureByteArray[1] = 0;
                }
            }
        }
    }

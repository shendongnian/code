    private void Dispose(bool disposing)
    {
        if (this.nativeFamily != IntPtr.Zero)
        {
            try
            {
                SafeNativeMethods.Gdip.GdipDeleteFontFamily(new HandleRef(this, this.nativeFamily));
            }
            catch (Exception exception)
            {
                if (ClientUtils.IsCriticalException(exception))
                {
                    throw;
                }
            }
            finally
            {
                this.nativeFamily = IntPtr.Zero;
            }
        }
    }

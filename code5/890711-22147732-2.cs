    public FontFamily[] Families
    {
        get
        {
            int numFound = 0x0;
            int status = SafeNativeMethods.Gdip.GdipGetFontCollectionFamilyCount(new HandleRef(this, this.nativeFontCollection), out numFound);
            if (status != 0x0)
            {
                throw SafeNativeMethods.Gdip.StatusException(status);
            }
            IntPtr[] gpfamilies = new IntPtr[numFound];
            int num3 = 0x0;
            status = SafeNativeMethods.Gdip.GdipGetFontCollectionFamilyList(new HandleRef(this, this.nativeFontCollection), numFound, gpfamilies, out num3);
            if (status != 0x0)
            {
                throw SafeNativeMethods.Gdip.StatusException(status);
            }
            FontFamily[] familyArray = new FontFamily[num3];
            for (int i = 0x0; i < num3; i++)
            {
                IntPtr ptr;
                SafeNativeMethods.Gdip.GdipCloneFontFamily(new HandleRef(null, gpfamilies[i]), out ptr);
                familyArray[i] = new FontFamily(ptr);
            }
            return familyArray;
        }
    }

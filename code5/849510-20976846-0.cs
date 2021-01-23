    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public int get_Width()
    {
        int num;
        int status = SafeNativeMethods.Gdip.GdipGetImageWidth(new HandleRef(this, this.nativeImage), out num);
        if (status != 0)
        {
            throw SafeNativeMethods.Gdip.StatusException(status);
        }
        return num;
    }
 

    public enum NORM_FORM
    {
        NormalizationOther = 0,
        NormalizationC = 0x1,
        NormalizationD = 0x2,
        NormalizationKC = 0x5,
        NormalizationKD = 0x6
    };
    [DllImport("Normaliz.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
    public static extern int NormalizeString(NORM_FORM NormForm,
        string lpSrcString,
        int cwSrcLength,
        StringBuilder lpDstString,
        int cwDstLength);
    public static string NormalizeString(string unnormalized, NORM_FORM form)
    {
        if (unnormalized == string.Empty)
        {
            return unnormalized;
        }
        int bufferSize = NormalizeString(form, unnormalized, unnormalized.Length, null, 0);
        if (bufferSize <= 0)
        {
            throw new Exception(string.Format("Win32 error: {0}", Marshal.GetLastWin32Error()));
        }
        var sb = new StringBuilder(bufferSize);
        int result = NormalizeString(form, unnormalized, unnormalized.Length, sb, bufferSize);
        if (result <= 0)
        {
            throw new Exception(string.Format("Win32 error: {0}", Marshal.GetLastWin32Error()));
        }
        return sb.ToString();
    }

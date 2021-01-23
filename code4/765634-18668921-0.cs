    /// <summary>
    /// The framework uses by default "Richedit20W" in RICHED20.DLL.
    /// This needs 4 minutes to load a 2,5MB RTF file with 45000 lines.
    /// Richedit50W needs only 2 seconds for the same RTF document !!!
    /// </summary>
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams i_Params = base.CreateParams;
            try
            {
                // Available since XP SP1
                Win32.LoadLibrary("MsftEdit.dll"); // throws
    
                // Replace "RichEdit20W" with "RichEdit50W"
                i_Params.ClassName = "RichEdit50W";
            }
            catch
            {
                // Windows XP without any Service Pack.
            }
            return i_Params;
        }
    }

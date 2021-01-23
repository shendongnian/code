    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
    public byte[] m_Text;
    public string Text
    {
        get
        {
            return m_Text != null ? Encoding.UTF8.GetString(m_Text).TrimEnd('\0') : string.Empty;
        }
        set
        {
            m_Text = Encoding.UTF8.GetBytes(value ?? string.Empty);
            Array.Resize(ref m_Text, 96);
            m_Text[95] = 0;
        }
    }

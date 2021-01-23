    public static void EnableControls(bool enable, params WebControl[] controls)
    {
        foreach (WebControl c in controls)
        {
            if (c != null) c.Enabled = enable;
        }
    }

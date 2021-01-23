    public System.Windows.Forms.Keys ShortCutKeys
    {
        get
        {
            string keyboardShortcut = ConfigurationManager.AppSettings["KeyboardShortcut"];
            System.Windows.Forms.Keys retval = System.Windows.Forms.Keys.None;
            if (!string.IsNullOrEmpty(keyboardShortcut))
            {
                try
                {
                     System.Windows.Forms.KeysConverter kc = new System.Windows.Forms.KeysConverter();
                     retval = (System.Windows.Forms.Keys)kc.ConvertFromInvariantString(keyboardShortcut);
                }
                catch (Exception ex)
                {
                    log.Info(ex.ToString());           
                }
           }
           return retval;
        }
    }

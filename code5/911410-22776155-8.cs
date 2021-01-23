    static ColorMapper()
    {
        foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
        {
            if (!ignoredColors.Contains(kc))
            {
                Color c = Color.FromKnownColor(kc);
                try
                {
                    colorMap.Add(c.ToArgb() & 0x00FFFFFF, c.Name);
                }
                //duplicate colors cause an exception
                catch { }
            }
        }
    }

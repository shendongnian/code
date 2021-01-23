    private RunStyles checkForEmphasis(Paragraph pTag)
        {
            bool isItalic = false;
            bool isBold = false;
            bool isUnderline = false;
            foreach (Run r in pTag.Descendants<Run>())
            {
                if (r.RunProperties != null)
                {
                    RunProperties rProp = r.RunProperties;
                    if (rProp.Italic != null)
                    {
                        int x;
                        isItalic = true;
                    }
                    else
                    {
                        isItalic = false;
                    }
                    if (rProp.Bold != null)
                    {
                        isBold = true;
                    }
                    else
                    {
                        isBold = false;
                    }
                    if (rProp.Underline != null)
                    {
                        isUnderline = true;
                    }
                    else
                    {
                        isUnderline = false;
                    }
                }
                else
                {
                    isItalic = false;
                    isBold = false;
                    isUnderline = false;
                }
            }
            if (isItalic && isBold && isUnderline)
            {
                return RunStyles.AllStyles;
            }
            else if (isBold && isItalic)
            {
                return RunStyles.BoldItalic;
            }
            else if (isBold && isUnderline)
            {
                return RunStyles.BoldUnderLine;
            }
            else if (isItalic && isUnderline)
            {
                return RunStyles.ItalicUnderLine;
            }
            else if (isItalic)
            {
                return RunStyles.Italic;
            }
            else if (isBold)
            {
                return RunStyles.Bold;
            }
            else if (isUnderline)
            {
                return RunStyles.UnderLine;
            }
            else
            {
                return RunStyles.NoStyle;
            }
        }

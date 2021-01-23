    private void TextBoxesReadOnlyTrue(Control.ControlCollection cc)
    {
        foreach (Control ctrl in cc)
        {
            TextBox tb = ctrl as TextBox;
            if (tb != null && tb.ReadOnly)
            { tb.ReadOnly = false; continue; }
            GroupBox gb = ctrl as GroupBox;
            if (gb != null) { TextBoxesReadOnlyTrue(gb.Controls); }
            /* do the same for a Panel here, as we did with
               GroupBox if you want to recurs Panels too. */
        }
    }

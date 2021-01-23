    private void TextBoxesReadOnlyTrue(Control.ControlCollection cc)
    {
        foreach (Control ctrl in cc)
        {
            TextBox tb = ctrl as TextBox;
            if (tb != null && tb.ReadOnly)
            { tb.ReadOnly = false; continue; }
            if (ctrl.Controls != null && ctrl.Controls.Count > 0)
            { TextBoxesReadOnlyTrue(ctrl.Controls); }
            // this recursively calls this same method for every control ...
            // that is a container control that contains more controls, ...
            // such as GroupBoxes, Panels, etc.
        }
    }

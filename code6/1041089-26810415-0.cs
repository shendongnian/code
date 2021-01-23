    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
    {
        e.DrawBackground();
        e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Bounds);
        Font f = cboCategory.Font;
        e.Graphics.DrawString(cboCategory.Items[e.Index].ToString(), f, new SolidBrush(ColorTranslator.FromHtml(cat_color2[e.Index])), e.Bounds, StringFormat.GenericDefault);
        e.DrawFocusRectangle();
    }

    public static void AddHorizontalRule(Section section, double percentWidth, Color? color = null)
    {
        double percent = (percentWidth < 0.0 || percentWidth > 1.0) ? 1.0 : percentWidth;
        Color hrColor = color ?? new Color(96, 96, 96); // Lt Grey default
        Unit contentWidth = section.PageSetup.PageWidth - section.PageSetup.LeftMargin - section.PageSetup.RightMargin;
        Unit indentSize = (contentWidth - (percent * contentWidth)) / 2.0;
        Paragraph paragraph = section.AddParagraph();
        paragraph.Format.LeftIndent = indentSize;
        paragraph.Format.RightIndent = indentSize;
        paragraph.Format.Borders.Top.Visible = true;
        paragraph.Format.Borders.Left.Visible = false;
        paragraph.Format.Borders.Right.Visible = false;
        paragraph.Format.Borders.Bottom.Visible = false;
        paragraph.Format.Borders.Top.Color = hrColor;
    }

    public static class TextUtils
    {
        const TextFormatFlags AlignFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.Bottom;
        const TextFormatFlags PaddingFlags = TextFormatFlags.NoPadding | TextFormatFlags.LeftAndRightPadding;
        const TextFormatFlags EllipsisFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.WordEllipsis | TextFormatFlags.PathEllipsis;
        const TextFormatFlags CalcRectFlag = (TextFormatFlags)0x400;
        public static Rectangle GetHighlightRectangle(IDeviceContext dc, string text, int highlightStart, int highlightLength, Font font, Rectangle bounds, TextFormatFlags flags = TextFormatFlags.SingleLine)
        {
            if ((flags & TextFormatFlags.SingleLine) == 0) throw new InvalidOperationException("This method only handles single line highlights. Multiline text highlights may be composed of multiple rectangles.");
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Text must not be null or empty.", "text");
            if (highlightStart < 0) throw new ArgumentOutOfRangeException("highlightStart", highlightLength, "Highlight length must be greater than or equal to zero.");
            if (highlightLength <= 0) throw new ArgumentOutOfRangeException("highlightLength", highlightLength, "Highlight length must be greater than zero.");
            if (highlightLength > text.Length - highlightStart) throw new ArgumentOutOfRangeException("highlightLength", highlightLength, "Highlight length must be less than or equal to the length of the text minus the highlight start.");
            var drawTextParams = GetTextMargins(font, flags);
            Size totalSize;
            
            // Determine total size and adjust for cut-off highlight.
            // We need access to the modified string in case it was trimmed.
            // Unfortunately, TextFormatFlags.ModifyString can't be used with TextRenderer.MeasureText
            // so we'll have to roll our own.
            var hdc = dc.GetHdc();
            try
            {
                var modifiedText = new StringBuilder(text);
                var rectBounds = new RECT(0, 0, bounds.Width, bounds.Height);
                var hFont = font.ToHfont();
                try
                {
                    var oldFont = Gdi32.SelectObject(hdc, hFont);
                    try
                    {
                        User32.DrawTextEx(hdc, modifiedText, modifiedText.Length, ref rectBounds, (flags & ~AlignFlags) | CalcRectFlag | TextFormatFlags.ModifyString, ref drawTextParams);
                    }
                    finally
                    {
                        Gdi32.SelectObject(hdc, oldFont);  
                    }
                }
                finally
                {
                    Gdi32.DeleteObject(hFont);
                }
                totalSize = new Size(rectBounds.Right - rectBounds.Left, rectBounds.Bottom - rectBounds.Top);
                
                // drawTextParams.uiLengthDrawn may be equal to text.Length even if an ellipsis was applied
                for (var i = 0; i < drawTextParams.uiLengthDrawn; i++)
                    if (modifiedText[i] != text[i])
                    {
                        var unchangedLength = i;
                        if (highlightStart > unchangedLength) highlightStart = unchangedLength;
                        if (highlightStart + highlightLength > unchangedLength) highlightLength = modifiedText.Length - highlightStart;
                        text = modifiedText.ToString();
                        break;
                    }
            }
            finally
            {
                dc.ReleaseHdc();
            }
            
            // Find the end of the highlight first rather than the beginning. This avoids having to explicitly deal with kerning.
            // Kerning may move the first highlighted character closer to the previous character. As long as the two characters
            // are measured together, kerning is taken into consideration.
            // The rectangle extends to the full beginning of the highlighted text, even when kerning moves it. 
            var highlightXEnd = drawTextParams.iLeftMargin + TextRenderer.MeasureText(dc, text.Substring(0, highlightStart + highlightLength), font, bounds.Size, (flags & ~(PaddingFlags | AlignFlags | EllipsisFlags)) | TextFormatFlags.NoPadding).Width;
            // We don't care about the kerning of the first character *following* the highlight. This way the highlight is inclusive on both ends.
            // The rectangle extends to the full end of the highlighted text, regardless of how close the following character comes.
            var highlightSize = TextRenderer.MeasureText(dc, text.Substring(highlightStart, highlightLength), font, bounds.Size, (flags & ~(PaddingFlags | AlignFlags | EllipsisFlags)) | TextFormatFlags.NoPadding);
            
            var unalignedHighlightBounds = new Rectangle(bounds.X + highlightXEnd - highlightSize.Width, bounds.Y, highlightSize.Width, highlightSize.Height);
            
            return ApplyAlignment(unalignedHighlightBounds, bounds.Width - totalSize.Width, bounds.Height - totalSize.Height, flags);
        }
        
        
        // Mimic TextRenderer's margins (see WindowsGraphics.GetTextMargins)
        private static User32.DRAWTEXTPARAMS GetTextMargins(Font font, TextFormatFlags flags)
        {
            var overhangPadding = font.Height / 6f;
            const float italicPaddingFactor = 0.5f;
            switch (flags & PaddingFlags)
            {
                case TextFormatFlags.GlyphOverhangPadding:
                    return new User32.DRAWTEXTPARAMS(Marshal.SizeOf(typeof(User32.DRAWTEXTPARAMS)))
                    {
                        iLeftMargin = (int)Math.Ceiling(overhangPadding),
                        iRightMargin = (int)Math.Ceiling(overhangPadding * (1 + italicPaddingFactor))
                    };
                case TextFormatFlags.LeftAndRightPadding:
                    return new User32.DRAWTEXTPARAMS(Marshal.SizeOf(typeof(User32.DRAWTEXTPARAMS)))
                    {
                        iLeftMargin = (int)Math.Ceiling(overhangPadding * 2),
                        iRightMargin = (int)Math.Ceiling(overhangPadding * (2 + italicPaddingFactor))
                    };
                case TextFormatFlags.NoPadding:
                    return new User32.DRAWTEXTPARAMS(Marshal.SizeOf(typeof(User32.DRAWTEXTPARAMS)))
                    {
                        iLeftMargin = 0,
                        iRightMargin = 0
                    };
                default:
                    throw new ArgumentException("Invalid combination of padding flags.", "flags");
            }
        }
        private static Rectangle ApplyAlignment(Rectangle rect, int widthDifference, int heightDifference, TextFormatFlags flags)
        {
            switch (flags & AlignFlags)
            {
                case TextFormatFlags.Top | TextFormatFlags.Left:
                    break;
                case TextFormatFlags.Top | TextFormatFlags.HorizontalCenter:
                    rect.Offset(widthDifference / 2, 0);
                    break;
                case TextFormatFlags.Top | TextFormatFlags.Right:
                    rect.Offset(widthDifference, 0);
                    break;
                case TextFormatFlags.VerticalCenter | TextFormatFlags.Left:
                    rect.Offset(0, heightDifference / 2);
                    break;
                case TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter:
                    rect.Offset(widthDifference / 2, heightDifference / 2);
                    break;
                case TextFormatFlags.VerticalCenter | TextFormatFlags.Right:
                    rect.Offset(widthDifference, heightDifference / 2);
                    break;
                case TextFormatFlags.Bottom | TextFormatFlags.Left:
                    rect.Offset(0, heightDifference);
                    break;
                case TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter:
                    rect.Offset(widthDifference / 2, heightDifference);
                    break;
                case TextFormatFlags.Bottom | TextFormatFlags.Right:
                    rect.Offset(widthDifference, heightDifference);
                    break;
                default:
                    throw new ArgumentException("Invalid combination of alignment flags.", "flags");
            }
            return rect;
        }
    }

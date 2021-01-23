     public void SetFontSizeForSelection(TextRange selection, double newFontSize)
            {
                if ((newFontSize - 0) < double.Epsilon)
                    newFontSize = 1;
                selection.ApplyPropertyValue(TextElement.FontSizeProperty, newFontSize);
            }

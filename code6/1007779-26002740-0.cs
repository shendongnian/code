    if (_highlightItem.SelectedBrush != null)
            {
                if (m_oComboBox.Resources.Contains(SystemColors.HighlightBrushKey))
                    m_oComboBox.Resources.Remove(SystemColors.HighlightBrushKey);
                m_oComboBox.Resources.Add(SystemColors.HighlightBrushKey, _highlightItem.SelectedBrush);
            }
 

           LinearGradientColorTable linGrBrush = new LinearGradientColorTable(
               Color.DarkGray,
               Color.DarkGray);
        
            Office2007Renderer renderer = GlobalManager.Renderer as Office2007Renderer;
            if (renderer == null) return;
            Office2007ColorTable table = renderer.ColorTable;
            // Stand-alone ComboBoxEx colors
            Office2007ComboBoxColorTable comboColors = table.ComboBox;
            comboColors.DefaultStandalone.Border = Color.DarkGray;
            comboColors.DefaultStandalone.Background = Color.White;
            comboColors.DefaultStandalone.ExpandText = Color.LightGray;
            comboColors.DefaultStandalone.ExpandBorderInner = linGrBrush;
            comboColors.DefaultStandalone.ExpandBorderOuter = linGrBrush;

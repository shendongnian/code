            using (Font f = new Font("Arial", 12f))
            {
                e.ToolTipSize = TextRenderer.MeasureText(
                    toolTips.GetToolTip(e.AssociatedControl), f);
            } 

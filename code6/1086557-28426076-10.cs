        public static void SetSelectionBackColor(this RichTextBox richTextBox, Color value)
        {
            if (richTextBox.IsHandleCreated && value == Color.Empty)
            {
                var cf2 = new CHARFORMAT2();
                cf2.dwEffects = RichTextBoxConstants.CFE_AUTOBACKCOLOR;
                cf2.dwMask = RichTextBoxConstants.CFM_BACKCOLOR;
                cf2.crBackColor = ColorTranslator.ToWin32(value);
                UnsafeNativeMethods.SendMessage(new HandleRef(richTextBox, richTextBox.Handle), RichTextBoxConstants.EM_SETCHARFORMAT, RichTextBoxConstants.SCF_SELECTION, cf2);
            }
            else
            {
                richTextBox.SelectionBackColor = value;
            }
        }

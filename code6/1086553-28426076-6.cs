        public Color SelectionBackColor {
            set
            {
                //Note: don't compare the value to the old value here: it's possible that 
                //you have a different range selected.
                selectionBackColorToSetOnHandleCreated = value;
                if (IsHandleCreated)
                {
                    NativeMethods.CHARFORMAT2A cf2 = new NativeMethods.CHARFORMAT2A();
                    if (value == Color.Empty)
                    {
                        cf2.dwEffects = RichTextBoxConstants.CFE_AUTOBACKCOLOR;
                    }
                    else
                    {
                        cf2.dwMask = RichTextBoxConstants.CFM_BACKCOLOR;
                        cf2.crBackColor = ColorTranslator.ToWin32(value);
                    }
 
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), RichTextBoxConstants.EM_SETCHARFORMAT, RichTextBoxConstants.SCF_SELECTION, cf2);
                }
            }
        }

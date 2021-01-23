        public string Text
        {
            get 
            {
                return GetText();
            }
            set
            {
                if (!API.setTextContents(this.VmId, this.Context, value))
                    throw new AccessibilityException("Error setting text");
            }
        }
        private string GetText()
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder();
            int caretIndex = 0;
            while (true)
            {
                API.AccessibleTextItemsInfo ti = new API.AccessibleTextItemsInfo();
                if (!API.getAccessibleTextItems(this.VmId, this.Context, ref ti, caretIndex))
                    throw new AccessibilityException("Error getting accessible text item information");
                if (!string.IsNullOrEmpty(ti.sentence))
                    sbText.Append(ti.sentence);
                else               
                    break;
                
                caretIndex = sbText.Length;
            }
            return sbText.ToString().TrimEnd();
        }

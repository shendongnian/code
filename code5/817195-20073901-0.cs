     private bool TryCopyToClipboard(string contents)
        {
            int i = 0;
            bool IsCopied = false;
            while (i <= 3)
            {
                try
                {
                    System.Windows.Clipboard.Clear();
                    System.Windows.Clipboard.SetText(Body);
                    if (System.Windows.Clipboard.GetText().Length == Body.Length)
                    {
                        IsCopied = true;
                        break;
                    }
                }
                catch (System.Exception)
                {
                }
                finally
                {                   
                    i++;
                }
            }
            return IsCopied;
        }
  

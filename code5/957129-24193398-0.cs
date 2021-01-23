        try
        {
            ...
        }
        catch (Exception ex)
        {
            string message = "";
            string formatString = "{0}: {1}";
            do
            {
                message += string.Format(formatString, ex.GetType(), ex.Message);
                ex = ex.InnerException;
                formatString = "\n    Inner {0}: {1}";
            }
            while (ex != null);
            MessageBox.Show(message);
        }

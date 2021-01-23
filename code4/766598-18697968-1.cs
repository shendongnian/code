    public void PerformAction(object sender, EventArgs args)
    {
            try
            {
                res = (T)(object)args.Result;
                var cook = Regex.Matches(wc.ResponseHeaders.ToString(), "Set\\-Cookie:\\s*([\\w\\-_\\.]+\\s*=\\s*[^;]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
                foreach (Match val in cook)
                    cookies += val.Groups[1].Value.Trim() + "; ";
                isComplited = true;
            }
            catch (Exception e)
            {
                lastError = e.InnerException.Message;
            }
    }

       using (StreamWriter streamWriter = new StreamWriter(context.Response.OutputStream))
        {
            streamWriter.WriteLine(string.Concat("Status=", status.ToString()));
            streamWriter.WriteLine(string.Concat("RedirectURL=", redirectUrl));
            streamWriter.WriteLine(string.Concat("StatusDetail=", HttpUtility.HtmlEncode(statusDetail)));
            streamWriter.Flush();
            streamWriter.Close();
        }

    public static string XPathAddDeafultNameSpaceProccess(this string XPathProcess)
            {
                string[] XPSplit = XPathProcess.Split('/');
    
                for (int i = 0; i < XPSplit.Length; i++)//if element no namespace, add default
                {
                    if (!XPSplit[i].Contains(':') && !XPSplit[i].Contains('@'))
                        XPSplit[i] = "default:" + XPSplit[i];
                }
                for (int i = 0; i < XPSplit.Length; i++)
                {
                    if (i != XPSplit.Length - 1)//if not the last, add"/"                       
                    XPSplit[i] += "/";
                }
    
                string output = "";
                foreach (string s in XPSplit)//combine
                    output += s;
                return output;
            }

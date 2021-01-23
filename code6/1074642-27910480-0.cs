        static void Main(string[] args)
        {
            // Split original string on the 'separator' string.
            string originalString = "&lt;p&gt;LARGE&lt;/p&gt;&lt;p&gt;Lamb;<br>;li;ul;&nbsp;";
            string[] sSeparator = new string[] { "&lt;/p&gt;&lt;p&gt;" };
            string[] splitString = originalString.Split(sSeparator, StringSplitOptions.None);
            // Prepare to filter the 'prefix' and 'postscript' strings
            string prefix = "&lt;p&gt;";
            string postfix = ";<br>;li;ul;&nbsp;";
            int prefixLength = prefix.Length;
            int postfixLength = postfix.Length;
            // Iterate over the split string and clean up
            string s = string.Empty;
            for (int i = 0; i < splitString.Length; i++)
            {
                s = splitString[i];
                if (s.Contains(prefix))
                {
                    s = s.Remove(s.IndexOf(prefix), prefixLength);
                }
                if (s.Contains(postfix))
                {
                    s = s.Remove(s.IndexOf(postfix), postfixLength);
                }
                splitString[i] = s;
                Console.WriteLine(splitString[i]);
            }
            Console.ReadLine();
        }

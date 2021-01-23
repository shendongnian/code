           string ss = "(FB+AB+ESI) / 12";
            string[] spl =  ss.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string final = spl[0].Replace("(", "").Replace(")", "").Trim();
            string[] entries = final.Split(new char[] {'+'}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sbFinal = new StringBuilder();
            sbFinal.Append("{");
            foreach(string en in entries)
            {
                sbFinal.Append(en + ",");
            }
            string finalString = sbFinal.ToString().TrimEnd(',');
            finalString += "}";

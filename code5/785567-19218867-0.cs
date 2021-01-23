            if (System.Text.RegularExpressions.Regex.IsMatch(bufferincmessage, Properties.Settings.Default.REQLogin, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                ...
            }else{
                if (System.Text.RegularExpressions.Regex.IsMatch(bufferincmessage, /*some of your command1*/, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {}
                else if (System.Text.RegularExpressions.Regex.IsMatch(bufferincmessage, /*some of your command1*/, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {}
                // and etc.
            }

        string input = "<cite class=Rm>https://www.example.com/<b>index</b>.<b>php</b>?<b>username</b>=laura</cite>";
    	string pattern = "(?'open'<(?'tag'[^ ]*)[^>]*>)(?'middle'.*?)(?'close-open'</\\k'tag'>)";
    	string replacement = "${middle}";
    	string step1 = System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement);
    	string result = System.Text.RegularExpressions.Regex.Replace(step1, pattern, replacement);

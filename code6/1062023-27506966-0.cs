    string src = @"[olist]
        [#]This is line 1
        [#]This is line 2
            [olist]
                [#]This is line 2.1
                [#]This is line 2.2
                [#]This is line 2.3
            [/olist]
        [#]This is line 3
    [/olist]";
    var replaced = Regex.Replace(src, @"\[#\](.*?)\r\n", match => "<li>" + match.Groups[1].Value + "</li>\r\n")
       .Replace("[olist]", "<ol>")
       .Replace("[/olist]", "</ol>");
    Console.WriteLine(replaced);

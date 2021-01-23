    var htmlText = // get the text you're trying to convert.
    var convertedText = System.Text.Encoding.ASCII.GetString(
        System.Text.Encoding.Convert(
            System.Text.Encoding.Unicode,
            System.Text.Encoding.ASCII,
            System.Text.Encoding.Unicode.GetBytes(htmlText)));

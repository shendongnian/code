    string unicode = "<tag>some proӸematic text<tag>";
    string escapedASCII = StringUtilities.HtmlEncode(
        unicode, Encoding.Unicode, Encoding.ASCII);
    // Result: &lt;tag&gt;some pro&#1272;ematic text&lt;tag&gt;
    

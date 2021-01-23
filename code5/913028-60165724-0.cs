public static string HtmlDecode(string input) {
    string decodedInput = WebUtility.HtmlDecode(input);
    if (input == decodedInput) {
        return input;
    }
    return HtmlDecode(decodedInput);
}
`WebUtility` is in the `System.Net` namespace.

    using System.Text.RegularExpressions;
    // .html document returned by page
    string webRequestResponse = getResponse();
    // site error string
    const string REGEX = "Password is not correct.";
    // check if page contain that error
    bool wrongPassword = Regex.IsMatch(webRequestResponse, REGEX);

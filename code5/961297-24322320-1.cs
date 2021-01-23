    ...
    using System.Net; //required for Webclient
    ...
            class Program
            {
                //entry point of console app
                static void Main(string[] args)
                {
                    // url to download
                    // "var" means I am too lazy to write "string" and let compiler decide typing
                    var url = @"http://www.dsebd.org/displayCompany.php?name=NBL";
        
                    // creating object in using makes Garbage Collector delete it when using block ends, as opposed to standard cleaning after whole function ends
                    using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                    {
        
                        // simply download result to string, in this case it will be html code
                        string htmlCode = client.DownloadString(url);
                        // cut html in half op position of "Last Trade:"
                        // searching from beginning of string is easier/faster than searching in middle
                        htmlCode = htmlCode.Substring(
                            htmlCode.IndexOf("Last Trade:")
                            );
                        // select from .. to .. and then remove leading and trailing whitespace characters
                        htmlCode = htmlCode.Substring("2\">", "</font></td>").Trim();
                        Console.WriteLine(htmlCode);
                    }
                    Console.ReadLine();
                }
            }
            // http://stackoverflow.com/a/17253735/3147740 <- copied from here
            // this is Extension Class which adds overloaded Substring() I used in this code, it does what its comments says
            public static class StringExtensions
            {
                /// <summary>
                /// takes a substring between two anchor strings (or the end of the string if that anchor is null)
                /// </summary>
                /// <param name="this">a string</param>
                /// <param name="from">an optional string to search after</param>
                /// <param name="until">an optional string to search before</param>
                /// <param name="comparison">an optional comparison for the search</param>
                /// <returns>a substring based on the search</returns>
                public static string Substring(this string @this, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
                {
                    var fromLength = (from ?? string.Empty).Length;
                    var startIndex = !string.IsNullOrEmpty(from)
                        ? @this.IndexOf(from, comparison) + fromLength
                        : 0;
        
                    if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }
        
                    var endIndex = !string.IsNullOrEmpty(until)
                    ? @this.IndexOf(until, startIndex, comparison)
                    : @this.Length;
        
                    if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }
        
                    var subString = @this.Substring(startIndex, endIndex - startIndex);
                    return subString;
                }
            }

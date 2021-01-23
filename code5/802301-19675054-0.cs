    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using HtmlAgilityPack;
    namespace ConsoleApplication3 {
      class Program {
        static void Main(string[] args) {
          var text = @"My favourite search engine is http://www.google.com but 
    sometimes I also use <a href=""http://www.yahoo.com"">http://www.yahoo.com</a>
    <div>http://catchme.com</div>
    <script>
      var thisCanHurt = 'http://noescape.com';
    </script>";
          var doc = new HtmlDocument();
          doc.LoadHtml(text);
          var regex = new Regex(@"http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?", RegexOptions.IgnoreCase);
          var nodes = doc.DocumentNode.SelectNodes("//text()");
          foreach (var node in nodes) {
            if (node.ParentNode != null && (node.ParentNode.Name == "a" || node.ParentNode.Name == "script" || node.ParentNode.Name == "style")) {
              continue;
            }
            node.InnerHtml = regex.Replace(node.InnerText, (match) => {
              return string.Format(@"<a href=""{0}"">{0}</a>", match.Value);
            });
          }
          var builder = new StringBuilder(100);
          using (var writer = new StringWriter(builder)) {
            doc.Save(writer);
          }
          var compose = builder.ToString();
        }
      }
    }

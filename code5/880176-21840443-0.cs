    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using HtmlAgilityPack;
    namespace CharFormat {
      class Program {
        static void Main(string[] args) {
          var markup = @"<!DOCTYPE html>
    <html>
    <body>
    <h1>aaa Heading ilo araferi</h1>
    Thats <p>My <b>first</b> paragraph.</p>
    <p>My second paragraph.</p>
    <p>My third paragraph.</p>
    </body>
    </html>";
          var doc = new HtmlDocument();
          doc.LoadHtml(markup);
          var map = new List<HtmlNode>();
          var nodes = doc.DocumentNode.SelectNodes("//text()");
          var builder = new StringBuilder(markup.Length);
          for (var j = 0; j < nodes.Count; j++) {
            var node = nodes[j];
            builder.Append(node.InnerHtml);
            for (var i = 0; i < node.InnerHtml.Length; i++) {
              map.Add(node);
            }
          }
          var keyword = "Thats My first paragraph.";
          int index = builder.ToString().IndexOf(keyword);
          if (index >= 0) {
            var firstNode = map[index];
            var lastNode = map[index + keyword.Length - 1];
            firstNode.InnerHtml = "<span>" + firstNode.InnerHtml;
            lastNode.InnerHtml = lastNode.InnerHtml + "</span>";
          }
          var writer = new StringWriter();
          doc.Save(writer);
          markup = writer.ToString();
        }
      }
    }

    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using HtmlAgilityPack;
    using System;
    namespace Test {
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
            var ancestor = Ancestor(firstNode, lastNode);
            if (ancestor != null) {
              while (firstNode != null && Level(firstNode) - Level(ancestor) > 1) {
                firstNode = firstNode.ParentNode;
              }
              while (lastNode != null && Level(lastNode) - Level(ancestor) > 1) {
                lastNode = lastNode.ParentNode;
              }
              if (firstNode != null && lastNode != null && ancestor == Ancestor(firstNode, lastNode)) {
                var span = doc.CreateElement("span");
                ancestor.ChildNodes.Insert(ancestor.ChildNodes.IndexOf(firstNode), span);
                int start = ancestor.ChildNodes.IndexOf(firstNode);
                int end = ancestor.ChildNodes.IndexOf(lastNode);
                for (var i = start; i <= end; i++) {
                  var node = ancestor.ChildNodes[start];
                  ancestor.ChildNodes.Remove(start);
                  span.ChildNodes.Append(node);
                }
              }
            }
          }
          var writer = new StringWriter();
          doc.Save(writer);
          markup = writer.ToString();
        }
        public static HtmlNode Ancestor(HtmlNode a, HtmlNode b) {
          if (a == null) {
            throw new ArgumentNullException("a");
          }
          if (b == null) {
            throw new ArgumentNullException("b");
          }
          var parentsOfA = new List<HtmlNode>();
          while (a != null) {
            parentsOfA.Add(a);
            a = a.ParentNode;
          }
          while (b != null) {
            if (parentsOfA.Contains(b)) {
              return b;
            }
            b = b.ParentNode;
          }
          return null;
        }
        public static int Level(HtmlNode node) {
          int level = 0;
          while (node != null) {
            level++;
            node = node.ParentNode;
          }
          return level;
        }
      }
    }

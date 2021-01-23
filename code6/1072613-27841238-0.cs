     private static bool XmlEquals(string s1, string s2)
     {
          var firstElement = XElement.Parse(s1);
          var secondElement = XElement.Parse(s2);
          IntroduceClosingBracket(firstElement);
          IntroduceClosingBracket(secondElement);
          return XNode.DeepEquals(firstElement, secondElement);
     }
     private static void IntroduceClosingBracket(XElement firstElement)
     {
          foreach (var descendant in firstElement.Descendants())
          {
               if (descendant.IsEmpty)
               {
                    descendant.SetValue(String.Empty);
               }
          }
     }

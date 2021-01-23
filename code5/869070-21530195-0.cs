             internal static class CrossSiteScriptingValidation
             {
              private static char[] startingChars = new char[2]
              {
               '<',
               '&'
              };
               static CrossSiteScriptingValidation()
             {
             }
                 private static bool IsAtoZ(char c)
               {
                if ((int) c >= 97 && (int) c <= 122)
                return true;
                if ((int) c >= 65)
                return (int) c <= 90;
               else
               return false;
              }
             
                  internal static bool IsDangerousString(string s, out int matchIndex)
                 {
                 matchIndex = 0;
                 int startIndex = 0;
                while (true)
                 {
                   int index = s.IndexOfAny(CrossSiteScriptingValidation.startingChars, startIndex);
                   if (index >= 0 && index != s.Length - 1)
                  {
                   matchIndex = index;
                 switch (s[index])
                  {
                    case '&':
                   if ((int) s[index + 1] != 35)
                    break;
                   else
                   goto label_7;
                    case '<':
                      if (CrossSiteScriptingValidation.IsAtoZ(s[index + 1]) || (int) s[index + 1] == 33 || ((int) s[index + 1] == 47 || (int) s[index + 1] == 63))
                 goto label_5;
              else
                break;
                 }
                   startIndex = index + 1;
                }
                 else
                 break;
              }
                return false;
              label_5:
               return true;
                label_7:
                 return true;
                }
                }
 

            private static readonly Regex _tags_ = new Regex(@"<[^>]+?>", RegexOptions.Multiline | RegexOptions.Compiled);
            //add characters that are should not be removed to this regex
            private static readonly Regex _notOkCharacter_ = new Regex(@"[^\w;&#@.:/\\?=|%!() -]", RegexOptions.Compiled);
            public static String UnHtml(String html)
            {
                html = HttpUtility.UrlDecode(html);
                html = HttpUtility.HtmlDecode(html);
                html = RemoveTag(html, "<!--", "-->");
                html = RemoveTag(html, "<script", "</script>");
                html = RemoveTag(html, "<style", "</style>");
                //replace matches of these regexes with space
                html = _tags_.Replace(html, " ");
                html = _notOkCharacter_.Replace(html, " ");
                html = SingleSpacedTrim(html);
                return html;
            }
            private static String RemoveTag(String html, String startTag, String endTag)
            {
                Boolean bAgain;
                do
                {
                    bAgain = false;
                    Int32 startTagPos = html.IndexOf(startTag, 0, StringComparison.CurrentCultureIgnoreCase);
                    if (startTagPos < 0)
                        continue;
                    Int32 endTagPos = html.IndexOf(endTag, startTagPos + 1, StringComparison.CurrentCultureIgnoreCase);
                    if (endTagPos <= startTagPos)
                        continue;
                    html = html.Remove(startTagPos, endTagPos - startTagPos + endTag.Length);
                    bAgain = true;
                } while (bAgain);
                return html;
            }
            private static String SingleSpacedTrim(String inString)
            {
                StringBuilder sb = new StringBuilder();
                Boolean inBlanks = false;
                foreach (Char c in inString)
                {
                    switch (c)
                    {
                        case '\r':
                        case '\n':
                        case '\t':
                        case ' ':
                            if (!inBlanks)
                            {
                                inBlanks = true;
                                sb.Append(' ');
                            }   
                            continue;
                        default:
                            inBlanks = false;
                            sb.Append(c);
                            break;
                    }
                }
                return sb.ToString().Trim();
            }

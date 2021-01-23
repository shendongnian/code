            XmlNodeList _Nodelist = _doc.SelectNodes("/root");
            foreach (XmlNode root in _Nodelist)
            {
                XmlNode _data = root.SelectSingleNode("data");
                if (_data == null)
                    continue;
                XmlNodeList _CommentNodes = _data.SelectNodes("comment");
                foreach (XmlNode _comment in _CommentNodes)
                {
                    var text = _comment.InnerText;
                    // text = "[Font][/Font][DateStamp][/DateStamp[Comment][/Comment]"
                    string _font = text.Between("[Font]", "[/Font]", StringComparison.Ordinal);
                    string _Date = text.Between("[DateStamp]", "[/DateStamp]", StringComparison.Ordinal);
                    string _Comment = text.Between("[Comment]", "[/Comment]", StringComparison.Ordinal);
                }
            }

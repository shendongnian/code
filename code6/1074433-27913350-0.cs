    List<String> title = new List<String>();
    List<String> st = new List<String>();
    foreach (Microsoft.Office.Interop.Word.Paragraph paragraph in oMyDoc.Paragraphs )
            {
                Microsoft.Office.Interop.Word.Style style = paragraph.get_Style() as Microsoft.Office.Interop.Word.Style;
                string styleName = style.NameLocal;
                string text = paragraph.Range.Text;
                if (styleName == "Title")
                {
                    title.Add(text.ToString());
                }
                else if (styleName == "Subtitle")
                {
                    st.Add(text.ToString());
                }
                else if (styleName=="Heading 1")
                {
                    heading1[h1c] = text.ToString()+"\n";
                }
    }

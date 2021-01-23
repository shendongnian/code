    string[] headings = {"Heading 1", "Heading 2", "Heading 3"};
    string[] paragraphs = {"Content", "content again","Content even again!"};
    literal1.Text = "";
    for (int i=0; i<headings.Length;i++)
    {
        literal1.Text = string.Format("{0}<h1>{1}</h1><p>{2}</p>{3}", literal1.Text, HttpServerUtility.HtmlEncode(headings[i]), HttpServerUtility.HtmlEncode(paragraphs[i]), Environment.Newline);
    }

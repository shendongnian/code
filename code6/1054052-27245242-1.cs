        StringBuilder html = new StringBuilder();
        for (int index = 1; index <= cell.Text.ToString().Length; index++)
        {
            //cell here is a Range object
            Characters ch = cell.get_Characters(index, 1);
            bool bold = (bool) ch.Font.Bold;
            if(bold){
                     if (html.Length == 0)
                          html.Append("<b>");
                     html.Append(ch.Text);
             }
        }
        if (html.Length !=0) sb.Append("</b>")

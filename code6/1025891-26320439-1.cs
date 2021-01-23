    private void recruit_Click(object sender, EventArgs e)
    {
         HtmlElementCollection elems = web.Document.GetElementsByTagName("a");
         foreach (HtmlElement elem in elems)
         {
             String value = elem.GetAttribute("value");
             //you can use elem.InnerText.Equals("Recruit") too, if value == null.
             if (value != null && value.Length != 0 && value.Equals("Recruit"))
             {
                 elem.InvokeMember("click");
             }
         }
     }

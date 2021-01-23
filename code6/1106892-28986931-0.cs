     protected void Page_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("directory", "*.html");
            StringBuilder htmlContent = new StringBuilder();
            foreach (string f in files)
            {
    
                htmlContent.Append(ReadHtmlFile(f));
            }
    
            lthtml.Text = htmlContent.ToString();
        }
    
    
       public static StringBuilder ReadHtmlFile(string htmlFileNameWithPath)
       {
                System.Text.StringBuilder htmlContent = new    System.Text.StringBuilder();
                string line;
                try
                {
                    using (System.IO.StreamReader htmlReader = new System.IO.StreamReader(htmlFileNameWithPath))
                    {
    
                        while ((line = htmlReader.ReadLine()) != null)
                        {
                            htmlContent.Append(line);
                        }
                    }
                }
                catch (Exception objError)
                {
                    throw objError;
                }
    
                return htmlContent;
            }

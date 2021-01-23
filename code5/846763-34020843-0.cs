    static void Replace(string filename, string a, string b)
        {
            using (DocX document = DocX.Load(filename))
            {
                document.ReplaceText(a, b);
                document.Save();
            } 
        }

    class Program
    {
        static void Main(string[] args)
        {
            MyWordDocument doc = new MyWordDocument("somedoc.docx"); //todo: fix path
            foreach (string name in doc.Tags) //name would be the extracted name from the placeholder
            {
                doc.ReplaceTagWithValue(name, "Example");
            }
            doc.Save("output.docx"); //todo: fix path
        }
    }

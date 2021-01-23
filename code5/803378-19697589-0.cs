    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] strArray = new string[50];
                string str = "SampleText<b>Billgates</b><p>This is Para</p><b>SteveJobs</b>ThisisEnd";
                Regex expression = new Regex(@"\<b\>(.*?)\</b\>");
                for (int i = 0; i < expression.Matches(str).Count; ++i)
                {
                    string value = expression.Matches(str)[i].ToString();
                    value = value.Replace("<b>", "");
                    value = value.Replace("</b>", "");
                    strArray[i] = value;
                }
                Console.WriteLine(strArray[0]);
                Console.WriteLine(strArray[1]);
                Console.ReadLine();
            }
        }
    }

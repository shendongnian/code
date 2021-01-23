    class Program
        {
            static void Main(string[] args)
            {
                string lang = "java,php,c#,asp.net,spring,hibernate";
               
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<Languages>");
                foreach (string s in lang.Split(','))
                {
                    sb.AppendFormat("<lang Name=\"{0}\"/>", s);
                }
                sb.AppendFormat("</Languages>");
                Console.WriteLine(sb.ToString());
                Console.ReadLine();
            }
        }

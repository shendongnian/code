    static public void RegexTry()
    {
        StreamReader stream = new StreamReader(@"test.xml");
        string xmlfile = stream.ReadToEnd();
        stream.Close();
        string text = "";
        for (int i = 0; i < 128; i++ )
        {
            char t = (char) i;
            text = xmlfile.Replace('П', t);
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Char("+i.ToString() +"): " + t + " => error! " + ex.Message);
                continue;
            }
            Console.WriteLine("Char(" + i.ToString() + "): " + t + " => fine!");
        }
        Console.ReadKey();
    }

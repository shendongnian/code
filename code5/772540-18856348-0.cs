    using System;
    using System.Xml;
    namespace ReadXMLfromFile
    {
    /// <summary>
    /// Общее описание класса Class1.
    /// </summary>
    class Class1
    {
        static void Main(string[] args)
        {
            XmlTextReader reader = new XmlTextReader ("books.xml");
            while (reader.Read())  
            {
                switch (reader.NodeType)  
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: // Вывести текст в каждом элементе.
                        Console.WriteLine (reader.Value);
                        break;
                    case XmlNodeType.EndElement: // Вывести конец элемента.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
    }

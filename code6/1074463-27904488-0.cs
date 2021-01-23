    private void button1_Click(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            DateTime start, end;
            DateTime.TryParse(textBox1.Text, out start);
            DateTime.TryParse(textBox2.Text, out end);
            float suma = 0.0f;
            float.TryParse(textBox3.Text, out suma);
            //Added this new line. Boolean parameter (true) here means append to existing content. 
            using (var stream = new StreamWriter("c:/users/ideapad/documents/visual studio 2013/Projects/XmlReader/XmlReader/rezervari.xml", true))
            {
                //Changed this line
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Rezervari");
                    writer.WriteStartElement("Rezervare");
                    writer.WriteElementString("ID", ID);
                    writer.WriteElementString("start", start.ToShortDateString());
                    writer.WriteElementString("end", end.ToShortDateString());
                    writer.WriteElementString("suma", suma.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
            }
        }

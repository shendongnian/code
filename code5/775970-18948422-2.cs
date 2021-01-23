    private void btnAddKunde_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(filename))
            {
                using (File.Create(filename))
                {}
            }
            XElement xmlNode = new XElement("Kundenverwaltung",
                                            new XElement("KundenNr", txtKundenNr.Text),
                                            new XElement("Nachname", txtKundeNachname.Text),
                                            new XElement("Vorname", txtKundeVorname.Text),
                                            new XElement("Adresse", txtKundeAdresse.Text),
                                            new XElement("Ort", txtKundeOrt.Text),
                                            new XElement("Telefon", txtKundeTel.Text),
                                            new XElement("Mail", txtKundeMail.Text)
                );
            XElement xmlFile;
            try
            {
                xmlFile = XElement.Load(filename);
                xmlFile.Add(xmlNode);
                
            }
            catch (XmlException)
            {
                xmlFile = new XElement("Customers", xmlNode);
            }
            xmlFile.Save(filename);
            DataSet flatDataSet = new DataSet();
            flatDataSet.ReadXml(filename);
            DataTable table = flatDataSet.Tables[0];
            dataGridKunden.DataSource = table;
        }

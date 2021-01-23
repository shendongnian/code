            writer.WriteStartDocument();
            writer.WriteStartElement("LoanData"); // Have a root node
            writer.WriteStartElement("LoanID");
            writer.WriteString("9980001140");
            writer.WriteEndElement();
            writer.WriteStartElement("LoanAmount");
            writer.WriteString("150000");
            writer.WriteEndElement();
            writer.WriteStartElement("BORROWERS");
            writer.WriteStartElement("BORROWER");
            writer.WriteStartElement("FullName");
            writer.WriteString("Johnny Smoth");
            writer.WriteEndElement(); // FullName
            writer.WriteEndElement(); // BORROWER
            writer.WriteEndElement(); // BORROWERS
            writer.WriteEndElement(); // LoanData
            writer.WriteEndDocument();
            writer.Close();

    String Residence = xmlDoc.Descendants("Appointment").Single().Element("StateOfResidence");
    if(Residence == "NULL")
    {
        Residence = null;
    }

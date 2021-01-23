    foreach (EA.Connector conn in element.Connectors) {
        EA.Element newNote = Package.Elements.AddNew("MyNote", "Note");
        newNote.Subtype = 1;
        newNote.MiscData(3) = "idref=" + conn.ConnectorID + ";";
        newNote.Notes = "Some string";
        newNote.Update();
        //position calculation is left out here
        EA.DiagramObject k = diagram.DiagramObjects.AddNew(position, "");
        k.ElementID = newNote.ElementID;
        k.Sequence = 9;
        k.Update();
    }

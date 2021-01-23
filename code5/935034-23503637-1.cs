    private void ProcessContainerElement(XmlReader myReader)
    {
        while (whatever)
        {
            if ((myReader.Name == "IMPORTANT_VALUE"))
            {
                myReader.Read();
                string Counter = myReader.Value;
                Console.WriteLine(Attribute + " (found: " + Counter + ")");
                return;
            }
        }
    }

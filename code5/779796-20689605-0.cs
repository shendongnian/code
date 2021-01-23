    // ******************************************************************
    public static SimulScenario LoadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            return new SimulScenarioError(path);
        }
        SimulScenario simulScenario = null;
        XmlTextReader reader = new XmlTextReader(path);
        XmlSerializer x = new XmlSerializer(typeof(SimulScenario));
		x.UnknownAttribute +=x_UnknownAttribute;
		x.UnknownElement += x_UnknownElement;
		x.UnknownNode += x_UnknownNode;
		x.UnreferencedObject += x_UnreferencedObject;
		try
        {
            simulScenario = (SimulScenario)x.Deserialize(reader);
        }
        catch (Exception)
        {
            return new SimulScenarioError(path);
        }
        finally
        {
            reader.Close();
        }
        return simulScenario;
    }
	static void x_UnreferencedObject(object sender, UnreferencedObjectEventArgs e)
	{
		
	}
	static void x_UnknownNode(object sender, XmlNodeEventArgs e)
	{
		
	}
	static void x_UnknownElement(object sender, XmlElementEventArgs e)
	{
		var simulChangeState = e.ObjectBeingDeserialized as SimulChangeState;
		if (simulChangeState != null)
		{
			if (e.Element.Name == "Included")
			{
				bool val;
				if (bool.TryParse(e.Element.InnerText, out val))
				{
					simulChangeState.IsIncluded = val;
				}
				else
				{
					throw new FileFormatException(Log.Instance.AddEntry(LogType.LogError, "Invalid scenario file format."));
				}
			}
		}
	}
	static void x_UnknownAttribute(object sender, XmlAttributeEventArgs e)
	{
		
	}

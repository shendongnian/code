	XmlReaderSettings settings = new XmlReaderSettings();
	settings.IgnoreWhitespace = false;
	using(XmlReader reader = XmlReader.Create(xmlFilepath, settings)) {
		while (reader.Read())
		{
		    switch (reader.NodeType)
		    {
		        case XmlNodeType.Element: // The node is an Element.
		            sb.Append("<" + reader.Name);
		
		            while (reader.MoveToNextAttribute()) // Read attributes.
		                sb.Append(" " + reader.Name + "='" + reader.Value + "'");
		            sb.Append(">");
		            sb.Append(">");
		            break;
		        case XmlNodeType.Text: 
		        case XmlNodeType.Whitespace:
		            sb.Append(reader.Value);
		            break;
		        case XmlNodeType.EndElement: //Display end of element.
		            sb.Append("</" + reader.Name);
		            sb.Append(">");
		            break;
		    }
		}
	}
	MessageBox.Show(sb.ToString());
	byte[] postBytes = Encoding.UTF8.GetBytes(sb.ToString());

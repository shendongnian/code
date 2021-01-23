    			_folderviewContents =
				new XDocument(
					new XElement("InterfaceIdentifier", "835"),
					//Start of FolderPaths 
					new XElement("FolderPaths",
						new XElement("Folder",
							new XAttribute("fromDate", String.Empty),
							//attributes for Folder w/ lots of attributes
							new XAttribute("toDate", String.Empty),
							new XAttribute("contactName", "APerson"),
							new XAttribute("email", "AnEmail"),
							//value for that long Folder w/ lots of attributes
							"Remittance Advice"),
				//Facility
						new XElement("Folder", String.Empty),
				//PayorID
						new XElement("Folder", String.Empty),
				//RemitDate Year
						new XElement("Folder", String.Empty),
				//RemitDate Month/Year
						new XElement("Folder", String.Empty)),
				new XElement("DocumentType", "RA"),
				new XElement("DocumentDescription",String.Empty),
				new XElement("TotalFiles", "1"));

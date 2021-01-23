	var xml = @"
	<Root>
	<System>
	<ID>1</ID>
	<Name>One</Name>
	<Monitor>
		<ID>2</ID>
		<Type>Two</Type>
		<Alert>
		<ID>3</ID>
		<Status>Three</Status>
		</Alert>
		<Alert>
		<ID>4</ID>
		<Status>Four</Status>
		</Alert>
	</Monitor>
	</System>
	<System>
	<ID>5</ID>
	<Name>Five</Name>
	<Monitor>
		<ID>6</ID>
		<Type>Six</Type>
		<Alert>
		<ID>7</ID>
		<Status>Seven</Status>
		</Alert>
	</Monitor>
	</System>
	</Root>
	";
	
	XElement xmlDoc = XElement.Parse(xml);
	var q = xmlDoc.Elements("System");
	
	foreach(var el in q) {
		Console.WriteLine(el.Element("ID").Value);
		Console.WriteLine(el.Element("Name").Value);
	
		foreach(var mon in el.Elements("Monitor")) {
			Console.WriteLine(mon.Element("ID").Value);
			Console.WriteLine(mon.Element("Type").Value);
			
			foreach(var alert in el.Elements("Alert")) {
				Console.WriteLine(alert.Element("ID").Value);
				Console.WriteLine(alert.Element("Status").Value);
			}
		}
	}

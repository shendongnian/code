	var xmlreceiveds =
		Observable
			.FromEventPattern<EventHandler<MessageResponseEventArgs>>(
				h => signalrClient.OnXMLReceived += h, 
				h => signalrClient.OnXMLReceived -= h);
			
	xmlreceiveds.Subscribe(ep =>
	{
		SaveCustomer(GetCustomerDataFrmXML(ep.EventArgs.XmlDoc));
		SavePlantInfo(GetPlantDataFrmXML(ep.EventArgs.XmlDoc));
		
		if (NotJobexists(GetJob(ep.EventArgs.XmlDoc)))
		{
			SaveJob(GetJobInfo(ep.EventArgs.XmlDoc));
		}
	});

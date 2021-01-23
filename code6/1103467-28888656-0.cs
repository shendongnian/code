        [Test]
		public void TestPopulateEVNOperaterID()
		{
			string message = @"MSH|^~\&|SUNS1|OVI02|AZIS|CMD|200606221348||ADT^A01|1049691900|P|2.3
    EVN|A01|200601060800
    PID||8912716038^^^51276|0216128^^^51276||BARDOUN^LEA SACHA||19981201|F|||AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150||053/12456789||N|S|||99120162652||^^^|||||B
    PV1||O|^^|U|||07632^MORTELO^POL^^^DR.|^^^^^|||||N||||||0200001198
    PV2|||^^AZIS||N|||200601060800
    IN1|0001|2|314000|||||||||19800101|||1|BARDOUN^LEA SACHA|1|19981201|AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150|||||||||||||||||ZIN|0164652011399|0164652011399|101|101|45789^Broken bone";
			var parser = new PipeParser();
			var abstractMessage = parser.Parse(message);
					
			// this is the normal / expected way of working with NHapi parsed messages
			var typedMessage = abstractMessage as ADT_A01;
			if (typedMessage != null)
			{
				typedMessage.EVN.OperatorID.FamilyName.Value = "Surname";
				typedMessage.EVN.OperatorID.GivenName.Value = "Firstname";
			}
			var pipeDelimitedMessage = parser.Encode(typedMessage);
			// alternatively, you can apply this modification to any HL7 2.3 message
			// with an EVN segment using this more generic method
			var genericMethod = abstractMessage as AbstractMessage;
			var evn = genericMethod.GetStructure("EVN") as EVN;
			if (evn != null)
			{
				evn.OperatorID.FamilyName.Value = "SurnameGeneric";
				evn.OperatorID.GivenName.Value = "FirstnameGeneric";
			}
			pipeDelimitedMessage = parser.Encode(typedMessage);
		}

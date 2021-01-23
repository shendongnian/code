    private string createHL7()
    {
    	ORU_R01 oruR01 = new ORU_R01();
    	ORU_R01_ORDER_OBSERVATION orderObservation = oruR01.GetRESPONSE().GetORDER_OBSERVATION();
    
    	ORU_R01_PATIENT patient = oruR01.GetRESPONSE().PATIENT;
    	ORU_R01_VISIT visit = patient.VISIT;
    	PV1 pv1 = visit.PV1;
    	
    	OBR obr = orderObservation.OBR;
    
    	ORU_R01_OBSERVATION observation = orderObservation.GetOBSERVATION(0);
    	OBX obx = observation.OBX;
    
    	oruR01.MSH.FieldSeparator.Value = "|";
    	oruR01.MSH.EncodingCharacters.Value = @"^~\&";
    	oruR01.MSH.SendingApplication.NamespaceID.Value = "SP";
    	oruR01.MSH.SendingFacility.NamespaceID.Value = "SPZH";
    	oruR01.MSH.ReceivingApplication.NamespaceID.Value = "MF";
    	oruR01.MSH.ReceivingFacility.NamespaceID.Value = "INTRA";
    	oruR01.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(DateTime.Now);
    	oruR01.MSH.ProcessingID.ProcessingID.Value = "P";
    	oruR01.MSH.VersionID.Value = "2.3";
    
    	PID pid = oruR01.GetRESPONSE().PATIENT.PID;
    	pid.SetIDPatientID.Value = "12345";
    	pid.PatientName.FamilyName.Value = "Joe";
    	pid.PatientName.GivenName.Value = "Bloggs";
    	pid.DateOfBirth.TimeOfAnEvent.SetLongDate(DateTime.MinValue);
    	pid.Sex.Value = "M";
    
    	pv1.SetIDPatientVisit.Value = "1";
    	pv1.VisitNumber.ID.Value = "3333333";
    	
    	obr.FillerOrderNumber.UniversalID.Value = "123456";
    	obr.UniversalServiceIdentifier.Text.Value = "Document";
    	obr.ObservationEndDateTime.TimeOfAnEvent.SetLongDate(DateTime.Now);
    	obr.ResultStatus.Value = "F";
    
    	obx.SetIDOBX.Value = "0";
    	obx.ValueType.Value = "RP";
    	obx.ObservationIdentifier.Identifier.Value = "Report";
    	
    	PipeParser parser = new PipeParser();
    	string encodedMessage = parser.Encode(oruR01);
    
    	return encodedMessage;
    }

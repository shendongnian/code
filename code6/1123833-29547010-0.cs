        using NHapi.Base.Parser;
        using NHapi.Model.V25.Message;
        using System;
        public class MessageTester
        {
            public static void Test()
            {
                var parser = new PipeParser();
                var adtMsg = new NHapi.Model.V25.Message.ADT_A01();
            
                adtMsg.MSH.MessageType.MessageCode.Value = "ADT";
                adtMsg.MSH.MessageType.TriggerEvent.Value = "A01";
                adtMsg.MSH.MessageType.MessageStructure.Value = "ADT_A01";
                adtMsg.MSH.FieldSeparator.Value = "|";
                adtMsg.MSH.EncodingCharacters.Value = @"^~\&";
                adtMsg.MSH.VersionID.VersionID.Value = "2.5";
                adtMsg.PID.SetIDPID.Value = "1";
                adtMsg.PID.CountyCode.Value = "ZAR";
                var name = adtMsg.PID.GetPatientName(0);
                name.PrefixEgDR.Value = "Mr";
                name.FamilyName.Surname.Value = "LastName";
                name.GivenName.Value = "FirstName";
                name.NameTypeCode.Value = "L";
                adtMsg.PID.AdministrativeSex.Value = "M";
                // The following returns a value of "ZAR", as expected.
                Console.WriteLine("Pre-Encoded ADT_A01 CountryCode: {0}", adtMsg.PID.CountyCode.Value);
                // The following returns a value of 1, as expected.
                Console.WriteLine("Pre-Encoded ADT_A01 PatientNameRepititionsUsed: {0}", adtMsg.PID.PatientNameRepetitionsUsed);
                var encodedADT_A01 = parser.Encode(adtMsg);
                var parsedADT_A01 = parser.Parse(encodedADT_A01) as ADT_A01;
                // After parsing the encoded message the following returns a value of "ZAR", as expected.
                Console.WriteLine("Parsed ADT_A01 CountryCode: {0}", parsedADT_A01.PID.CountyCode.Value);
                // After parsing the encoded message the following returns a value of 1, as expected.
                Console.WriteLine("Parsed ADT_A01 PatientNameRepititionsUsed: {0}", parsedADT_A01.PID.PatientNameRepetitionsUsed);
                Console.WriteLine("----------------------------------------------------------------");
                var refMsg = new NHapi.Model.V25.Message.REF_I12();
                refMsg.MSH.MessageType.MessageCode.Value = "REF";
                refMsg.MSH.MessageType.TriggerEvent.Value = "I12";
                refMsg.MSH.MessageType.MessageStructure.Value = "REF_I12";
                refMsg.MSH.FieldSeparator.Value = "|";
                refMsg.MSH.EncodingCharacters.Value = @"^~\&";
                refMsg.MSH.VersionID.VersionID.Value = "2.5";
                // THIS LINE OF CODE FIXED THE ISSUE
                refMsg.GetPROVIDER_CONTACT(0).PRD.GetProviderName(0).FamilyName.Surname.Value = "DummyProviderLastName";
                refMsg.PID.SetIDPID.Value = "1";
                refMsg.PID.CountyCode.Value = "ZAR";
                name = refMsg.PID.GetPatientName(0);
                name.PrefixEgDR.Value = "Mr";
                name.FamilyName.Surname.Value = "LastName";
                name.GivenName.Value = "FirstName";
                name.NameTypeCode.Value = "L";
                refMsg.PID.AdministrativeSex.Value = "M";
                // The following returns a value of "ZAR", as expected.
                Console.WriteLine("Pre-Encoded REF_I12 CountryCode: {0}", refMsg.PID.CountyCode.Value);
                // The following returns a value of 1, as expected.
                Console.WriteLine("Pre-Encoded REF_I12 PatientNameRepititionsUsed: {0}", refMsg.PID.PatientNameRepetitionsUsed);
                var encodedREF_I12 = parser.Encode(refMsg);
                var parsedREF_I12 = parser.Parse(encodedREF_I12) as REF_I12;
                // After parsing the encoded message the following returns nothing, where "ZAR" is expected.
                Console.WriteLine("Parsed REF_I12 CountryCode: {0}", parsedREF_I12.PID.CountyCode.Value);
                // After parsing the encoded message the following returns a value of 0, where 1 is expected.
                Console.WriteLine("Parsed REF_I12 PatientNameRepititionsUsed: {0}", parsedREF_I12.PID.PatientNameRepetitionsUsed);
            }
        }

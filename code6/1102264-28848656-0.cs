      var parser = new PipeParser();
      var messageParsed = parser.Parse(message);
      var a03 = messageParsed as ADT_A03;
    
      var setId = a03.PV1.SetIDPatientVisit.Value;
      var patientClass = a03.PV1.PatientClass.Value;
      var AssignedPatientLocation = a03.PV1.AssignedPatientLocation.PointOfCare.Value;
      var Admission_Type = a03.PV1.AdmissionType.Value;
      var Pre_Admit_Number = a03.PV1.PreadmitNumber.ID.Value;
      var Prior_Patient_Location = a03.PV1.PriorPatientLocation.PointOfCare.Value;
      var Attending_Doctor_Id = a03.PV1.AttendingDoctor.IDNumber.Value;
      var Attending_Doctor_Name = a03.PV1.AttendingDoctor.FamilyName.Value;
      var Referring_Doctor_Id = a03.PV1.ReferringDoctor.IDNumber.Value;
      var Referring_Doctor_Name = a03.PV1.ReferringDoctor.FamilyName.Value;

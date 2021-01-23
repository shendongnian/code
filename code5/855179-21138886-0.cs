    SomeData.Where(visit => ids.Contains(visit.Id))
                    .ToDictionary(visit => visit.Id, visit =>
                    {
                        var visit = visit.NewVisit;
                        bool isEwusCheck = visit.Patient.EwusChecks.Any(
                            check =>
                                check.X_RemoveTime == null && check.IsInsured);
    
                        bool isEuDocument = visit.Patient.EuPatientDocuments.Any(
                            document =>
                                document.ValidFrom.Date <= visit.StartTime.Date &&
                                document.ValidTo.Date >= visit.StartTime.Date);
    
                        bool isDeclatarion =
                            visit.Patient.Documents.Any(
                                document =>
                                    document.PatientDocumentType.IsDocumentDeclaration &&
                                    document.ValidFrom.Date <= visit.StartTime.Date &&
                                    document.ValidTo.Date >= visit.StartTime.Date);
    
                        return new NfzPatientInsuranceInfoModel(visit.PatientId, isEwusCheck || isEuDocument || isDeclatarion, isEuDocument);
                    });

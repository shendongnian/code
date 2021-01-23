        public class PatientAlertsSummary
        {
            public bool IsViewed;
            public int PatientID;
        }
        public class PatientTherapist
        {
            public int PatientID;
            public int TherapistID;
        }
        [TestMethod]
        public void Test1()
        {
            //UPDATE PatientAlertsSummary
            //SET IsViewed =1 
            //WHERE  PatientID IN (SELECT PatientID FROM PatientTherapist WHERE TherapistID=@TherapistID)
            var therapistId = 1;
            var patientAlertsSummaries = new List<PatientAlertsSummary>() { 
                new PatientAlertsSummary(){PatientID = 1},
                new PatientAlertsSummary(){PatientID = 2},
                new PatientAlertsSummary(){PatientID = 3}
            };
            var PatientTherapists = new List<PatientTherapist>() { 
                new PatientTherapist(){PatientID = 1 , TherapistID = 1},
                new PatientTherapist(){PatientID = 2 , TherapistID = 1},
                new PatientTherapist(){PatientID = 3, TherapistID = 2}
            };
            var updatedPatinets1 = PatientTherapists.
                Where(o => o.TherapistID == therapistId).
                Join(patientAlertsSummaries,
                patientTherapist => patientTherapist.PatientID,
                patientAlertsSummary => patientAlertsSummary.PatientID,
                (o, p) => 
                    {
                        UpdateIsViewed(p);
                        return p;
                    }).ToList();
        }

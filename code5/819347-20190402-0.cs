                    foreach (Factuur huidigeFactuur2 in e.SelectedObjects)
                {
                    XmlSerializer serializer2 = new XmlSerializer(typeof(KilometerUpload));
                    TextWriter writer = new StreamWriter(@"C:\test2.xml");
                    string chassisnummer = huidigeFactuur2.Wagen.Chassisnummer;
                    string kilometerstatus = huidigeFactuur2.KMStand.ToString();
                    KilometerUpload item = new KilometerUpload
                    {
                        KilometerRegistration = new KilometerUploadKilometerRegistration[] { new KilometerUploadKilometerRegistration{ ChassisNumber = chassisnummer , TypeOfData = "120", KilometerStatus = kilometerstatus} },
                    };
                    serializer2.Serialize(writer, item);

    switch (Enroller.TemplateStatus)
                        {
                            case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                                OnTemplate(Enroller.Template);
                                MemoryStream fingerprintData = new MemoryStream();
                                Enroller.Template.Serialize(fingerprintData);
                                fingerprintData.Position = 0;
                                BinaryReader br = new BinaryReader(fingerprintData);
                                Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
                                Enroller.Template.Serialize(ref bytes);
                                string basestring = Convert.ToBase64String(bytes);
                                string fingerprint_ = basestring;
    
                                Stop();
                                break;
    }

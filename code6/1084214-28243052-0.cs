    List<RsvpData> cleanRsvpData = new List<RsvpData>();
            foreach (RsvpData rsvp in rsvps)
            {
                try
                {
                    RsvpData data = rsvp.ToRsvpData(students[x.RawAgentId]);
                    if (rsvp.Completed)
                    {
                        data.SignatureUrl = "test";
                        var cert = certificates.FirstOrDefault(c => c.Rsvp.RsvpId == x.RsvpId);
                        data.CertificateId = cert != null ? cert.CertId.ToString() : "";
                    }
                    cleanRsvpData.Add(data);
                }
                catch (Exception ex)
                { // handle error here
                }
            }

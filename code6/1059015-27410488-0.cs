        public Stream PatientCheckinWithDemos(Stream streamdata) {
            try {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ApptData));
                ApptData data = (ApptData)ser.ReadObject(streamdata);
                c.WriteToLog("Appt id is " + data.ID);
                c.WriteToLog("PatientFirst is " + data.PatientFirst);
                c.WriteToLog("PatientLast is " + data.PatientLast);
                c.WriteToLog("PtEmail is " + data.PtEmail);
                c.WriteToLog("Sex is " + data.Sex);
                c.WriteToLog("Birthdate is " + data.Birthdate);
                return GetStream("something");
            } catch (Exception e) {
                c.WriteToLog("Failure during Database Call to PatientCheckinWithDemos " + e.Message);
                return GetStream("");
            }
        }

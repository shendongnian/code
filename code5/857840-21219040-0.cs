            var builder = new StringBuilder();
            builder.Append("SELECT appointmentID, aDate, aTime, aStatus, aContact, aHeight, aWeight, p.pFirstName , m.mcCentre , n.nFirstName From APPOINTMENT");
            builder.AppendLine("AS a LEFT OUTER JOIN Nurse AS n ON a.nurseID = n.NurseID");
            builder.AppendLine("Left outer join Patient as p on a.patientid = p.patientId");
            builder.AppendLine("left outer join medicalcentre as m on a.mcID = m.mcid");
            
            var commandText = builder.ToString();   

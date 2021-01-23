     foreach (DataRow DRA in DTBA.Rows)
          {
              message.Attachments.Add(AttachmentFile(2, DRA["FILENAME"].ToString().Trim(), 0, null));
              RecordLine("DEBUG 3.1 - " + message.Attachments.Count.ToString());
          }

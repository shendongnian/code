                string SummaryText = String.Format("File Name {0} / {1}", "", filenameonly);;
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                    var progress = bytesRead * 100.0 / writeStream.Length;
                    bw.ReportProgress((int)progress,SummaryText);
                }

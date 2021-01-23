            do
            {
            if (e.Cancel)
            {  
               return;
            }
            if (!reader.EOF)
            {
               ExtractDataFromStream(reader);
            }
            else
            {
                throw new Exception("EOF");
            }
            MONITOR.ReportProgress(0);
         } while (bwStreamData.IsBusy);

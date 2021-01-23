    private void DoWhatever(string path)
    {
        try
        {
            Directory.GetFiles(path)
                     .ToList()
                     .ForEach(l_sFilename =>
                     {
                         m_qUpload.Enqueue(
                             new UploadDescriptor {
                                 BatchDescription = m_tbDescription.Text,
                                 BatchTimestamp = l_now,
                                 BatchId = l_sBatchId,
                                 Username = m_frmLogin.Username,
                                 TargetUsername = l_sTargetUsername,
                                 Filename = l_sFilename
                             }
                         );
                         AddProgressRow(l_sFilename);
                         l_nFilesInBatch++;
                         ms_sem.Release();
                     });
            Directory.GetDirectories(path)
                     .ToList()
                     .ForEach(s => DoWhatever(s));
        }
        catch (UnauthorizedAccessException ex)
        {
            // We're not authorized to access this directory. Who knows why. Ignore it.
        }
    }

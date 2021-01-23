    private void _archive_SaveProgress(object sender, SaveProgressEventArgs e)
    {
        switch (e.EventType)
        {
            case ZipProgressEventType.Saving_BeforeWriteEntry:
                if (e.EntriesTotal > 0)
                {
                    // Update the view with the total percentage progress.
                    int totalPercentage = (e.EntriesSaved / e.EntriesTotal) * 100m;
                    View.SavingStatus(e.CurrentEntry.FileName, 0, totalPercentage);
                }
                break;
            case ZipProgressEventType.Saving_EntryBytesRead:
                int filePercentage = 0;
                if (e.BytesTransferred == 0)
                {
                    filePercentage = 0;
                }
                else
                {
                    filePercentage = (new decimal(e.BytesTransferred) / new decimal(e.TotalBytesToTransfer)) * 100m;
                }
                // Update the view with the current file percentage.
                View.SavingStatus("Archiving file " + e.CurrentEntry.FileName + "...", filePercentage, -1);
                break;
            case ZipProgressEventType.Saving_Completed:
                View.SavingStatus("Archive creation complete, saving data changes...", 100, 100);
                break;
        }
    }

    class ObservableFilesTransmitted : ViewableCollection<FilesTransmitted>
    {
        DocControlDC _dc = null;
        int _jobID = 0;
        public ObservableFilesTransmitted(DocControlDC dataDc, int ID)
        {
            _dc = dataDc;
            _jobID = ID;
        }
        public void FillCollection()
        {
            foreach (FilesTransmitted ftran in _dc.FilesTransmitteds.Where(x=>x.JobID==_jobID).OrderByDescending(x => x.TransmittalName))
            {
                this.Add(ftran);
            }
        }
    }

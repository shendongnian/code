    class tdoc
    {
        public int xID {get; set;}
        public int TransID { get; set; }
        public System.String TransmittalName { get; set; }
        public System.String FileName { get; set; }
        public System.String DocumentNumber { get; set; }
        public System.String REV { get; set; }
        public System.DateTime REVDate { get; set; }
        public System.String Title { get; set; }
        public int? rID { get; set; }
        public int? CODE { get; set; }
        public System.String RTNTrans { get; set; }
        public System.String RtnFile { get; set; }
    }
    class ObservableTrackDocument : ObservableCollection<TrackDocument>
    {
        public ObservableTrackDocument(DocControlClassesDataContext dataDc)
        {
            IEnumerable<tdoc> query = from f in dataDc.FilesTransmitteds
                                               from r in dataDc.FilesReturneds
                                               .Where(r => f.DocumentNumber == r.DocumentNumber && f.REV == r.REV)
                                               .DefaultIfEmpty()
                                               select new tdoc
                                               {
                                                   xID = f.UID,
                                                   TransID = (int)f.TransID,
                                                   TransmittalName = f.TransmittalName,
                                                   FileName = f.FileName,
                                                   DocumentNumber = f.DocumentNumber,
                                                   REV = f.REV,
                                                   REVDate = (System.DateTime)f.REVDate,
                                                   Title = f.Title,
                                                   rID = r.UID,
                                                   CODE = r.CODE,
                                                   RTNTrans = r.RTNTrans,
                                                   RtnFile = r.FileName
                                               };
            foreach (tdoc Doc in query)
            {
                TrackDocument d = new TrackDocument();
                d.xID = Doc.xID;
                d.TransID = Doc.TransID;
                d.TransmittalName = Doc.TransmittalName;
                d.FileName = Doc.FileName;
                d.DocumentNumber = Doc.DocumentNumber;
                d.REV = Doc.REV;
                d.REVDate = Doc.REVDate;
                d.Title = Doc.Title;
                d.rID = Doc.rID;
                d.CODE = Doc.CODE;
                d.RTNTrans = Doc.RTNTrans;
                d.RtnFile = Doc.RtnFile;
                this.Add(d);
            }
        }
    }

        private List<byte> BackImageBytes;
        [Editor(typeof(MyMetafileEditor), typeof(UITypeEditor))]
        public List<byte> BackImage {
            get { return BackImageBytes; }
            set {
                BackImageBytes = value;
                if (value == null) base.BackgroundImage = null;
                else base.BackgroundImage = new Metafile(new System.IO.MemoryStream(value.ToArray()));
            }
        }

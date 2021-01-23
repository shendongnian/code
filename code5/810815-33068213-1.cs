            [VisualFieldType(typeof(EditField))]
            [VisualProperty("Max file size limit (MB) :", 5)]
            public string FileSizeLimit
            {
                get
                {
                    return this._fileSizeLimit.ToString();
                }
                set
                {
                    this._fileSizeLimit = int.Parse(value);
                }
            }

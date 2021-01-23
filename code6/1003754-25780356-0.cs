        /// <summary>
        /// Database and Application Version
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 MajorVersion
        {
            get
            {
                return _MajorVersion;
            }
            set
            {
                if (_MajorVersion != value)
                {
                    OnMajorVersionChanging(value);
                    ReportPropertyChanging("MajorVersion");
                    _MajorVersion = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("MajorVersion");
                    OnMajorVersionChanged();
                }
            }
        } 

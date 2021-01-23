        [LayoutRenderer("UniqueName")]
        public class UniqueNameLayoutRenderer : LayoutRenderer
        {
            #region Fields (1)
    
            private string _constantName;
    
            #endregion Fields
    
            #region Enums (1)
    
            public enum PatternType
            {
                /// <summary>
                /// Long date + current process ID
                /// </summary>
                LongDateAndPID,
                /// <summary>
                /// Long date (including ms)
                /// </summary>
                LongDate,
            }
    
            #endregion Enums
    
            #region Properties (2)
    
            public string ConstantName
            {
                get
                {
                    if (_constantName == null)
                    {
                        if (Format == PatternType.LongDateAndPID)
                        {
                            string pid;
                            try
                            {
                                pid = Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                                pid = "000"; 
                            }
    
                            _constantName = DateTime.Now.ToString("yyyy-MM-dd_HHmmss-ffff") + "_pid" + pid;
                        }
                        else if (Format == PatternType.LongDate)
                        {
                            _constantName = DateTime.Now.ToString("yyyy-MM-dd_HHmmss-ffff");
                        }
                    }
    
                    return _constantName;
                }
            }
    
            [DefaultParameter]
            public PatternType Format { get; set; }
    
            #endregion Properties
    
            #region Methods (2)
    
            // Protected Methods (1) 
    
            protected override void Append(StringBuilder builder, LogEventInfo logEvent)
            {
                builder.Append(ConstantName);
            }
            // Private Methods (1) 
    
            #endregion Methods
        }
    }

        /// <summary>
        /// Step XAML
        /// </summary>
        [XmlElement("StepXaml")]
        public object StepXaml
        {
            get { return _StepXaml; }
            set 
            {
                if (_StepXaml != value)
                {
                    object _obj;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        // Convert the text into a byte array so that 
                        // it can be loaded into the memory stream.
                        XmlNode _node = (value as XmlNode[])[0];
                        if (_node is XmlCDataSection)
                        {
                            XmlCDataSection _cDataSection = _node as XmlCDataSection;
                            byte[] bytes = Encoding.UTF8.GetBytes(_cDataSection.Value);
                            
                            // Write the XAML bytes into a memory stream.
                            stream.Write(bytes, 0, bytes.Length);
                            // Reset the stream's current position back 
                            // to the beginning so that when it is read 
                            // from, the read begins at the correct place.
                            stream.Position = 0;
                            // Convert the XAML into a .NET object.
                            _obj = XamlReader.Load(stream);
                            _StepXaml = _obj;
                            NotifyPropertyChanged(m => m.StepXaml);
                        }
                    }
                }
            }
        }
        private object _StepXaml;

        class MyXmlReaderPatcher : XmlTextReader
        {
            private readonly HashSet<string> _currentNodeElementNames = new HashSet<string>();
            public MyXmlReaderPatcher(TextReader reader) : base(reader)
            { }
            public override bool Read()
            {
                var result = base.Read();
                if (this.Depth == 1)
                {
                    _currentNodeElementNames.Clear();
                }
                else if (this.Depth==2 && this.NodeType == XmlNodeType.Element)
                {
                    if (_currentNodeElementNames.Contains(this.Name))
                    {
                        var name = this.Name;
                        do {
                            result = base.Read();
                            if (result == false)
                                return false;
                        } while (this.NodeType != XmlNodeType.EndElement && this.Name != name);
                        result = this.Read();
                    }
                    else
                    {
                        _currentNodeElementNames.Add(this.Name);
                    }
                }
                return result;
            }
        }

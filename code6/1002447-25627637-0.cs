            static void Test(String _xmlFilename)
        {
            //string _path = @"C:\Development\XML\Batch1823.xml";
            String _path = _xmlFilename;
            XmlDocument xDoc = new XmlDocument();
            Dictionary<string, int> _marks = new Dictionary<string, int>();
            int _markCounter = 0;
            xDoc.Load(_path);
            foreach(XmlNode xRod in xDoc.SelectNodes("/ProductionLot/ProductionSet/Machine/Rod"))
            {
                String _finalRef = xRod.Attributes.GetNamedItem("finalReference").Value;
                String _color = xRod.Attributes.GetNamedItem("color").Value;
                foreach (XmlNode xPiece in xRod.SelectNodes("Piece"))
                {
                    String _length = xPiece.Attributes.GetNamedItem("length").Value;
                    String _angle = xPiece.Attributes.GetNamedItem("angle").Value;
                    String _angleA = xPiece.Attributes.GetNamedItem("angleA").Value;
                    String _angleB = xPiece.Attributes.GetNamedItem("angleB").Value;
                    String _operStr = "";
                    foreach (XmlNode xOper in xPiece.SelectNodes("Operations/Operation"))
                    {
                        String _operName = xOper.Attributes.GetNamedItem("name").Value;
                        String _operXPos = xOper.Attributes.GetNamedItem("X").Value;
                        _operStr = _operStr + "//" + _operName + ":" + _operXPos;
                    }
                    String _pieceMark = _finalRef + "/" + _color + "/" + _length + "/" + _angle + "/" + _angleA + "/" + "/" + _operStr + "/" + _angleB;
                    String _markID = "0";
                    if (!_marks.ContainsKey(_pieceMark))
                    {
                        _markCounter += 1;
                        _marks.Add(_pieceMark, _markCounter);
                        _markID = _markCounter.ToString();
                    }
                    else
                    {
                        _markID = _marks[_pieceMark].ToString();
                    }
                    xPiece.Attributes.Append(xDoc.CreateAttribute("group")).Value = _markID;
                }
            }
            xDoc.Save(_path);
        }

    Move m = new Move();
                m.oTags.Add(new Tag() { TagName = "X" });
                m.oTags.Add(new Tag() { TagName = "XX" });
    
                XmlSerializer x = new XmlSerializer(typeof(Move));
                System.IO.Stream s;
    
                var xmlwriter = System.Xml.XmlWriter.Create("C:\\MXL.txt"); 
                x.Serialize(xmlwriter, m);

    while(_reader.Read())
     {
       if (_reader.NodeType == XmlNodeType.Element)
       {
         if(_reader.HasAttributes && _reader.Name.Equals("pos"))
         {
           piecesOnBoard[indx] = _reader.GetAttribute("piece");
         }
       }
      indx++;
     }

     var DRCurrentAuspragung = _DTAuspragung.Select(@"MerkmalID = " + Convert.ToString(MerkmalID));
        
     _DTCurrentAuspragung = _DTAuspragung.Clone();
     for (int i = 0; i < DRCurrentAuspragung.Length; i++ )
     {
             DataRow RowAdd = DRCurrentAuspragung[i];
             _DTCurrentAuspragung.ImportRow(RowAdd);
     }

    String line = fileIn.ReadLine();
    String[] pieces = line.Split(',');
    if( pieces.Length == 6 ) 
    {
        pieces[2] = String.Concat(pieces[2], pieces[3]);
        pieces[3] = pieces[4];
        pieces[4] = pieces[5];
    }    
    csvComplete cEve = new csvComplete (pieces[0], pieces[1], pieces[2], pieces[3], pieces[4]);// assign to class cEve
    entries.Add(cEve);

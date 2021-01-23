    //Read the file
    while (!fileIn.EndOfStream)
    {
       String line = fileIn.ReadLine();
       String[] pieces = line.Split(',');
       if(pieces.length > 5){
           String[] newPieces = new String[5];
           newPieces[0] = pieces[0];
           newPieces[1] = pieces[1];
           String currency = "";
           for(int i = 2; i < pieces.length - 2; i++){
               if(i == pieces.length -3)
                   currency += pieces[i];
               else{
                   currency += pieces[i] + ",";
               }
           }
           newPieces[2] = currency;
           newPieces[3] = pieces[pieces.length-2];
           newPieces[4] = pieces[pieces.length-1];
           csvComplete cEve = new csvComplete (newPieces[0], newPieces[1], newPieces[2], newPieces[3], newPieces[4]);// assign to class cEve
           entries.Add(cEve);
       }
       else{
           csvComplete cEve = new csvComplete (pieces[0], pieces[1], pieces[2], pieces[3], pieces[4]);// assign to class cEve
           entries.Add(cEve);
       }
     }

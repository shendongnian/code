    aantalpersonen = int.Parse(tbArray.Text); 
    if (aantalpersonen > 5 || aantalpersonen <= 1)
        throw new ArgumentOutOfRangeException();
    else
    {
        Persoon[] personenLijst = new Persoon[aantalpersonen];
        for( int x = 0; x < personenLijst.Length ; x++)
        {
           personenLijst[x] = new Persoon();
        }
     }

    public static IEnumerable<Frequenz_und_Wert> FindPeaks(IEnumerable<Frequenz_und_Wert> lfw, int breite)
    {
        int decay = 0;
        Frequenz_und_Wert peak = new Frequenz_und_Wert();
        peak.Wert = 0;
        foreach (var value in lfw)
        {
            if (value.Wert > peak.Wert || decay > breite / 2)
            {
                peak.Wert = value.Wert;
                peak.Frequenz = value.Frequenz;
                decay = 0;
            }
            else
                decay++;
            if (decay == breite / 2)
            {
                    yield return peak;
                    peak = new  Frequenz_und_Wert(){Wert = peak.Wert, Frequenz = peak.Frequenz};
            }
        }
    }

    if(passengers > seats)
    {
        MessageBox.Show("For mange passagerer");
    }
    else
    {
        HashSet<int> taken = new HashSet<int>();
        for(int i = 0; i <= passengers - 1; i++)
        {
            int resultat;
            do {
                resultat = rnd.Next(1, seats + 1);
            } while(taken.Contains(resultat));
            taken.Add(resultat);
            listBoxFulde.Items.Add("Passager #" + (i+1) + "på sæde #" + resultat);
        }
        HashSet<int> ledige01 = new HashSet<int>(
            Enumerable.Range(1, seats));
        ledige01.ExceptWith(taken);
        // etc

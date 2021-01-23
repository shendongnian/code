    int KaibaDeckSize = KaibaDeck.Count;
    string sDrawChoice;
    int DrawChoice;
    while (KaibaDeckSize > 0)
    {
        if (DrawChoice == 0)
        {
            break;
        }
        else
        {
            KaibaBattlePhase(KaibaHand, KaibaDeck, 
                KaibaFusionDeck, YugiDeck, Field,
                KaibaGraveyard, YugiGraveyard, KaLP, YuLP, "Battle");
        }
        KaibaDeckSize = KaibaDeck.Count
    }

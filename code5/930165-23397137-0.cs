            bool MeerCCOl = true;
            int startpositie = 0;
            int CCOLfound = 0; // aantal keer dat terminal output is gevonden
            while(MeerCCOl)
            {
                Regex rgx = new Regex(":[0-5][0-9]:[0-5][0-9]", RegexOptions.Multiline | RegexOptions.Compiled);
                Match GevondenColon = rgx.Match(VlogDataGefilterd,startpositie);
                MeerCCOl = GevondenColon.Success; // CCOL terminal data gevonden, er is misschien nog meer..
                if (MeerCCOl && GevondenColon.Index >= 2)
                {
                    CCOLfound++;
                    int GevondenUur = 10 * (VlogDataGefilterd[GevondenColon.Index - 2] - '0') +
                                            VlogDataGefilterd[GevondenColon.Index - 1] - '0';
                    if (VlogDataGefilterd[GevondenColon.Index - 2] >= '0' && VlogDataGefilterd[GevondenColon.Index - 2] <= '2' &&
                        VlogDataGefilterd[GevondenColon.Index - 1] >= '0' && VlogDataGefilterd[GevondenColon.Index - 1] <= '9' &&
                        GevondenUur>=0 && GevondenUur<=23)
                    {
                        Regex rgx2 = new Regex("[012][0-9]:[0-5][0-9]:[0-5][0-9].*", RegexOptions.Multiline);
                        VlogDataGefilterd = rgx2.Replace(VlogDataGefilterd, string.Empty, 1, (GevondenColon.Index - 2));
                        startpositie = GevondenColon.Index - 2; // start volgende match vanaf de plek waar we de 
                    }
                }
            }

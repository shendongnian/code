        public void UtseVinnare(string _Val)
        {
            string SpelareVal = _Val;
            string _SpelarVal = _Val.ToUpper();
            string _DatornsVal = DatornsVal.ToUpper(); 
            if (_DatornsVal == _SpelarVal)
            {
                Interaction.MsgBox("Oavgjort!\nDitt val var: " + SpelareVal + "\n" + "Datorns val var: " + DatornsVal);
                string Val = Interaction.InputBox("Välj Sten, Sax eller Påse:");
                Starta();
                UtseVinnare(Val);
            }
            else if (_DatornsVal == "STEN" && _SpelarVal == "SAX" || _DatornsVal == "SAX" && _SpelarVal == "PÅSE" || _DatornsVal == "PÅSE"
                && _SpelarVal == "STEN")
            {
                Interaction.MsgBox("Du förlorade!\nDitt val var: " + SpelareVal + "\n" + "Datorns val var: " + DatornsVal);
                int spelare = 0;
                int dator = 1;
                if (Poang(dator, spelare))
                {
                    return;
                }
                string Val = Interaction.InputBox("Välj Sten, Sax eller Påse:");
                Starta();
                UtseVinnare(Val);
            }
            else if (_DatornsVal == "STEN" && _SpelarVal == "PÅSE" || _DatornsVal == "SAX" && _SpelarVal == "STEN" || _DatornsVal == "PÅSE"
                && _SpelarVal == "SAX")
            {
                Interaction.MsgBox("Du vann!\nDitt val var: " + SpelareVal + "\n" + "Datorns val var: " + DatornsVal);
                int spelare = 1;
                int dator = 0;
                if (Poang(dator, spelare))
                {
                    return;
                }
                string Val = Interaction.InputBox("Välj Sten, Sax eller Påse:");
                Starta();
                UtseVinnare(Val);
            }
        }
        public bool Poang(int _dator, int _spelare)
        {
            static int datorpoangraknare = 0;
            static int spelarpoangraknare = 0;
            if (_dator > _spelare)
            {
                datorpoangraknare++;
            }
            else
            {
                spelarpoangraknare++;
            }
            if (datorpoangraknare == 3)
            {
              Interaction.MsgBox("Datorn vann tre gånger!");
              return true;
            }
            if (spelarpoangraknare == 3)
            {
                Interaction.MsgBox("Du vann tre gåger!");
                return true;
            }
            return false;
        }

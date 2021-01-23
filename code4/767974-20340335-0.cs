                 if (Speech == "I WANT TO SEARCH SOMETHING")
                {
                    QEvent = Speech;
                    wiki.SpeakAsync("what do you want to search");
                    Speech = string.Empty;
                }
                else if (Speech != string.Empty && QEvent == "I WANT TO SEARCH SOMETHING")
                {
                    Process.Start("http://google.com/search?q=" + Speech);
                    QEvent = string.Empty;
                    Num = rnd.Next(1, 4);
                    if (Num == 1) { wiki.SpeakAsync("Alright, I am searching " + Speech + " in google"); }
                    else if (Num == 2) { wiki.SpeakAsync("ok sir, I am searching " + Speech); }
                    else if (Num == 3) { wiki.SpeakAsync("Alright, I am searching "); }
                    Speech = string.Empty;
                }

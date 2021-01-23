    using (StreamReader myRdr = new StreamReader(fileName))
            {
                string entireText;
                if((entireText= myRdr.ReadToEnd()) != null)
                {
                    string[] entireTextArray = entireText.Split('|');
                    foreach(string band in entireTextArray )
                    {
                    switch (band)
                    {
                        case "RockBand":
                            Band newBand = new RockBand(lineAra);
                            bands.Add(newBand);
                            bandsByName.Add(newBand.Name, newBand);
                            break;
                        case "JazzCombo":
                            Band newt = new JazzCombo(lineAra);
                            bands.Add(newt);
                            bandsByName.Add(newt.Name, newt);
                            break;
                        case "SoloAct":
                            Band newB = new SoloAct(lineAra);
                            bands.Add(newB);
                            bandsByName.Add(newB.Name, newB);
                            break;
                        default:
                            Band ddd = new Band(lineAra);
                            bands.Add(ddd);
                            bandsByName.Add(ddd.Name, ddd);
                            break;
                    }
                    }
                }
            }

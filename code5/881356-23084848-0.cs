    for (int Spalte = 0; Spalte < Anzahl; Spalte++)
                            {
                                DGV[Spalte].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                                for (int i = 0; i < counter[Spalte]; i++)
                                {
                                    DGV[Spalte][0, i].Value = meV[Spalte][i];
                                }
                                DGV[Spalte].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            }

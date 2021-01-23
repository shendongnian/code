                  if (tekstinkoopcrni.Text == "1") { } else if (tekstinkoopcrni.Text == "0") { } else { tekstinkoopcrni.Text = "0"; }
                    if (tekstinkoopkorting.Text == "") { tekstinkoopkorting.Text = "0"; }
                    if (tekstinkoopserievoorraad.Text == "") { tekstinkoopserievoorraad.Text = "0"; }
                    if (tekstinkoopstandleveran.Text == "") { tekstinkoopstandleveran.Text = "9999"; }
                    if (tekstinkooplevertijd.Text == "") { tekstinkooplevertijd.Text = "0"; }
                    SqlCommand slinkoopadd = new SqlCommand(@"insert into ART (ART ,OMS ,REM ,ARTDK ,TYPE ,MAG ,PROGRAM ,EH1 ,INK ,KOR ,SGR ,EH2 ,EF ,VALUTA ,CRNI  ,LEV ,LTD )
                                                                       values (@art,@oms,@rem,@artdk,@type,@mag,@program,@eh1,@ink,@kor,@sgr,@eh2,@ef,@valuta,@crni, @lev,@ltd);", Connectie.connMEVO_ART);
                    //                                                                                                                                                    LTD fixen/error vinden                                         
                    #region parameters
                    slinkoopadd.Parameters.Add("@art", SqlDbType.VarChar).Value = this.artnr.Text;
                    slinkoopadd.Parameters.Add("@oms", SqlDbType.VarChar).Value = this.tekstinkoopoms.Text;
                    slinkoopadd.Parameters.Add("@rem", SqlDbType.VarChar).Value = this.tekstinkoopopmerk.Text;
                    slinkoopadd.Parameters.Add("@artdk", SqlDbType.VarChar).Value = this.tekstinkoopnummerlev.Text;
                    slinkoopadd.Parameters.Add("@type", SqlDbType.VarChar).Value = this.tekstinkooparttype.Text;
                    slinkoopadd.Parameters.Add("@mag", SqlDbType.VarChar).Value = this.tekstinkoopmagazijnloc.Text;
                    slinkoopadd.Parameters.Add("@program", SqlDbType.VarChar).Value = this.tekstinkoopinternopmerk.Text;
                    slinkoopadd.Parameters.Add("@eh1", SqlDbType.VarChar).Value = this.tekstinkoopeenheid.Text;
                    slinkoopadd.Parameters.Add("@lev", SqlDbType.VarChar).Value = this.tekstinkoopstandleveran.Text;
                    slinkoopadd.Parameters.Add("@ltd", SqlDbType.VarChar).Value = this.tekstinkooplevertijd.Text;
                    slinkoopadd.Parameters.Add("@ink", SqlDbType.VarChar).Value = this.tekstinkoopbrutoprijs.Text;
                    slinkoopadd.Parameters.Add("@kor", SqlDbType.VarChar).Value = this.tekstinkoopkorting.Text;
                    slinkoopadd.Parameters.Add("@sgr", SqlDbType.VarChar).Value = this.tekstinkoopserievoorraad.Text;
                    slinkoopadd.Parameters.Add("@eh2", SqlDbType.VarChar).Value = this.tekstinkoopgebruikeh.Text;
                    slinkoopadd.Parameters.Add("@ef", SqlDbType.VarChar).Value = this.textinkoopehfactor.Text;
                    //slinkoopadd.Parameters.Add("@", SqlDbType.VarChar).Value = this.artnr.Text;//perc. voor vracht
                    slinkoopadd.Parameters.Add("@valuta", SqlDbType.VarChar).Value = this.tekstinkoopvaluta.Text;
                    slinkoopadd.Parameters.Add("@crni", SqlDbType.VarChar).Value = this.tekstinkoopcrni.Text;
                    //slinkoopadd.Parameters.Add("@", SqlDbType.VarChar).Value = this.artnr.Text;//extra kosten
                    //slinkoopadd.Parameters.Add("@", SqlDbType.VarChar).Value = this.artnr.Text;//bestelgrootte afroep
                    //slinkoopadd.Parameters.Add("@", SqlDbType.VarChar).Value = this.artnr.Text;//prognose jaarverbruik
                    //slinkoopadd.Parameters.Add("@", SqlDbType.VarChar).Value = this.artnr.Text;//levertijd nieuwe afr
                    #endregion
                    drART = slinkoopadd.ExecuteReader();
                    MessageBox.Show("Artikel opgeslagen!");
                    fillbox();
                    while (drART.Read())
                    { }
                    slinkoopadd.Dispose(); 

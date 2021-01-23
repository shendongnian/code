    var src_in_arac = from log in Src_Log_List.ToList()
                                  join ml in mail_arac_sorgu on log.Node equals ml.TasitTanımaNo
                                  join sr in surucu_list.Select(ss =>
                                  {
                                      string SCKartNo = "";
                                      string AdSoyad = ss.AdSoyad;
                                      if (ss.SrcKardId != "")
                                          SCKartNo = "000" + (Convert.ToInt64(ss.SrcKardId).ToString("X"));
                                      return new { AdSoyad, SCKartNo };
                                  })
                                  on log.SCID equals sr.SCKartNo
                                  into data
                                  from ss in data.DefaultIfEmpty()
                                  where log.Task == "GPSEvents"
                                  select new { log.Speed, AdSoyad = (ss == null ? "İZİNSİZ KULLANIM" : ss.AdSoyad), ml.Plaka, log.OdoMeter, log.StandStill, log.Date, ml.Grup, ml.Email ,log.SC};

	var list = from c in db.Mesai
                   join s in db.MesaiTip on c.mesaiTipID equals s.ID
                   where c.iseAlimID == iseAlimID
                   select new
                   {
                       tarih = c.mesaiTarih,
                       mesaiTip = s.ad,
                       mesaiBaslangic = c.mesaiBaslangic,
                       mesaiBitis = c.mesaiBitis,
                       sure = c.sure,
                       condition = c.onaylandiMi,
                       status = c.onaylandiMi != null ? c.status : "Not Confirmed"
                   };

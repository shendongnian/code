    return GetSession().Query<TabcMultimedia>()
        .Join(GetSession().Query<Immagini>(), l => l.fk_immagine, r => r.pk_immagine, (l, r) => new { Multimedia = l, Immagini = r })
        .Where(w => w.Multimedia.fk_schedatipo == (int)tipoScheda && w.Multimedia.fk_chiavescheda == pkScheda && w.Immagini.fk_tipo_immagini == 4)
        .OrderBy(o => o.Multimedia.ordine)
        .AsEnumerable()
        .Select(s => new Allegato {
            IdAllegato = s.Immagini.pk_immagine,
            Titolo = s.Multimedia.denom_ita != null ? VitCommon.ChooseLanguage(s.Multimedia, "denom", language) : VitCommon.ChooseLanguage(s.Immagini, "titolo", language),
            Didascalia = s.Multimedia.didasca_ita != null ? VitCommon.ChooseLanguage(s.Multimedia, "didasca", language) : VitCommon.ChooseLanguage(s.Immagini, "descrizione", language),
            Tassonomia = GetTassonomiaMultimedia(s.Multimedia.est_inv, listTassonoimieImmagini),
            Tipo = s.Immagini.immagine_tipo
        })
        .ToList();

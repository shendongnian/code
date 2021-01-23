    (from a in db.TITLE_CHECKLIST
    from t in db.Tipo_CheckList
    where a.ID_Tipo_Checklist == t.ID
    where a.ID_Tipo_Checklist == tipoCheckList
    select new //note were using an anonymous type here, 
               //as the real type can't take a non-list
    {
        Descripcion = a.Descripcion,
        Id = a.Id,
        ID_Tipo_Checklist = a.ID_Tipo_Checklist,
        Tipo_CheckList = new CTipo_CheckList
        {
            Descripcion = t.Descripcion,
            ID = t.ID,
            ID_Depto = t.ID_Depto
        },
        Subtitulos = from s in db.SUBTITLE_CHECKLIST
                    where s.ID_Title == a.Id
                    select new CSUBTITLE_CHECKLIST
                    {
                        AmountCK = s.AmountCK,
                        Descripcion = s.Descripcion,
                        ID = s.ID,
                        ID_Title = s.ID_Title,
                        Numeracion = s.Numeracion,
                        checkList = (from ck in db.CheckList
                                    where ck.ID_Subtitle == s.ID
                                    && ck.Codigo == codigo
                                    select new CCheckList
                                    {
                                        CK = ck.CK,
                                        Amount = ck.Amount,
                                        Codigo = ck.Codigo,
                                        Codigo_TFile = ck.Codigo_TFile,
                                        Comentario = ck.Comentario,
                                        ID = ck.ID,
                                        ID_Subtitle = ck.ID_Subtitle,
                                        UserCre = ck.UserCre,
                                        UserMod = ck.UserMod
                                    }).FirstOrDefault()
                    }//note no ToList
    })
    //This will ensure that all operators that follow
    //are done in memory, not on the DB end
    .AsEnumerable()
    .Select(checklist => new CTITLE_CHECKLIST
    {
        Descripcion = checklist.Descripcion,
        Id = checklist.Id,
        ID_Tipo_Checklist = checklist.ID_Tipo_Checklist,
        Subtitulos = Subtitulos.ToList(),
    });

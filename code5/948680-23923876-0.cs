    resultado.Dados =
    (
        from a in db.AgendaHorario
        join b in db.Agenda on a.AgendaID equals b.AgendaID
        join c in db.Profissional on a.ProfissionalID equals c.ProfissionalID into d
        from e in d.DefaultIfEmpty()                        
        select new
        {
            id = a.AgendaHorarioID,
            Medico = e.Identificacao,
            start = a.Horario
        }).AsEnumerable().Select(x => new
        {
            id = x.id,
            Medico = x.Medico,
            start = x.start.ToString("yyyy-MM-dd HH:mm:ss")            
        }
    );

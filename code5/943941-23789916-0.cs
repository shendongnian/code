    var ProcHardware = (from a in db.ProcessoHardwares
                                    group a by new { a.IDHardware, a.IDProcesso } into latest
                                    join b in db.ProcessoHardwares on new { dt = latest.Max(itm => itm.IDProcessoHardware) } equals new {  dt = b.IDProcessoHardware }
                                    select new { ID = b.IDHardware, Estado=b.Estado,IDProcesso=b.IDProcesso }).ToList().Where(t => t.Estado == 1 && t.IDProcesso == IDProcesso ).Select(c => new VMProcessoChooseHardware
                               {
                                   IDHardware = c.ID
                               });

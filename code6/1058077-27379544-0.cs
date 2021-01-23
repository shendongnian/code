       ListImport.Clear();
        using (var db = new Minorlex_MPIPSEntities())
        {
            var query = from s in db.tbl_Dokumenty
                        where s.IdDokumentu == 15 || s.DynamicCondition
                        select s;
            foreach (tbl_Dokumenty Dokument in query)
            {
                ListImport.Add(Dokument);
            }
        }

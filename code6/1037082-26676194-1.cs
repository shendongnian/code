            var listaReporte =
                (from t in dbContext.TablaPruebas
                 select new
                 {
                     Name = t.name,
                     Score = t.score
                 }
                ) .ToList();
            DataTable dt = Library.GridHelper.LINQToDataTable(listaReporte);

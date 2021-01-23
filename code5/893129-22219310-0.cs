     var newRowsInFirst = from r1 in first_table.AsEnumerable()
                         join r2 in analyse_table.AsEnumerable()
                         on   new { User=r1.Field<string>("User"), Modul=r1.Field<string>("Modul") }
                         equals new { User=r2.Field<string>("User"), Modul=r2.Field<string>("Modul") }
                         into gj from g2 in gj.DefaultIfEmpty()
                         where g2 == null
                         select r1;

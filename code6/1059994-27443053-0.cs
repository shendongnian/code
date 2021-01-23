    //datatable1
             DataTable dt1 = new DataTable();
            dt1.Columns.Add("Id");
            dt1.Columns.Add("Name");
            dt1.Columns.Add("Weight");
            DataRow dr ;
            dr = dt1.NewRow();
            dr["Id"] = 1;
            dr["Name"] = "Ship";
            dr["Weight"] = 500;
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["Id"] = 2;
            dr["Name"] = "Train";
            dr["Weight"] = 600;
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["Id"] = 3;
            dr["Name"] = "Plane";
            dr["Weight"] = 700;
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["Id"] = 4;
            dr["Name"] = "Car";
            dr["Weight"] = 400;
            dt1.Rows.Add(dr);
             //datatable2
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Id");
            dt2.Columns.Add("Name");
            dt2.Columns.Add("Weight");
            DataRow dr2;
            dr2 = dt2.NewRow();
            dr2["Id"] = 1;
            dr2["Name"] = "Ship";
            dr2["Weight"] = 500;
            dt2.Rows.Add(dr2);
            dr2 = dt2.NewRow();
            dr2["Id"] = 3;
            dr2["Name"] = "Plane";
            dr2["Weight"] = 700;
            dt2.Rows.Add(dr2);
            dr2 = dt2.NewRow();
            dr2["Id"] = 4;
            dr2["Name"] = "Car";
            dr2["Weight"] = 400;
            dt2.Rows.Add(dr2);
            //iterate through table1
            IEnumerable<DataRow> table1 = from r in dt1.AsEnumerable()
                                          select r;
            //iterate through table2
            IEnumerable<DataRow> table2 = from r in dt2.AsEnumerable()
                                          select r;
            Console.WriteLine("Id\tName\tWeight\tDatatable1\tDatatable2");
            Console.WriteLine("----------------------------------------------------");
            //prints the common records
            foreach (DataRow td1 in table1.Distinct())//Matches wholes of the Element Sequence inside IEnumerable
            {
                table2.Distinct().ToList().ForEach(td2 =>
                {
                    if (td1.Field<string>("Id") == td2.Field<string>("Id"))
                    {
                        Console.WriteLine(td1.Field<string>("Id") + "\t" + td1.Field<string>("Name") + "\t" + td1.Field<string>("Weight") + "\t" + "x" + "\t\t" + "x");
                    }
                });
            }
            //prints the missing records
            var query = (from tb1 in dt1.AsEnumerable()
                         join tb2 in dt2.AsEnumerable()
                         on tb1.Field<string>("Id") equals tb2.Field<string>("Id") into subset
                         from sc in subset.DefaultIfEmpty()
                         where sc == null
                         select new
                         {
                             id = tb1.Field<string>("Id"),
                             name = tb1.Field<string>("Name"),
                             wt = tb1.Field<string>("Weight")
                         }).Distinct();
            foreach (var td1 in query)
            {
                Console.WriteLine(td1.id + "\t" + td1.name + "\t" + td1.wt + "\t" + "x" + "\t\t" + "-");
            }

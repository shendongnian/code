            DataTable dt = new DataTable();
            dt.Columns.Add("ColA", typeof(string));
            dt.Columns.Add("ColB", typeof(string));
            dt.Columns.Add("ColC", typeof(string));
            dt.Columns.Add("ColD", typeof(string));
            dt.Rows.Add("A", null, "C", "D");
            for (int i = 1; i < 10; i++)
                dt.Rows.Add("A" + i, "B" + i, "C" + i, "D" + i);
            bool res =  dt.Conflicting(
                Tuple.Create<string,object>("ColA", "A1"),
                Tuple.Create<string,object>("ColB", "B1")
                );
            Console.WriteLine(res); //true
            res = dt.Conflicting(
                Tuple.Create<string, object>("ColA", "A1"),
                Tuple.Create<string, object>("ColB", "B11")
                );
            Console.WriteLine(res);//false
            res = dt.Conflicting(
               Tuple.Create<string, object>("ColA", "A2"),
               Tuple.Create<string, object>("ColB", "B2"),
               Tuple.Create<string, object>("ColC", "C2"),
               Tuple.Create<string, object>("ColD", "D2")
               );
            Console.WriteLine(res);//true
            res = dt.Conflicting(
                Tuple.Create<string, object>("ColA", "A"),
                Tuple.Create<string, object>("ColB", null)
                );
            Console.WriteLine(res);//true

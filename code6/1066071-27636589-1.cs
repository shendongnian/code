        var arrayOne = new []{"Germane", "Henry", "Charissa", "Evan", "Zorita"};
        var arrayTwo = new []{"Athena", "Darryl", "Zelenia", "Honorato", "Macon"};
        //var result1 = arrayOne.Where(x => x.Length > 3).Select(x => x.Length);
        bool condition1 = true;
        bool condition2 = false;
        bool condition3 = true;
        var fnc = (Func<IEnumerable, IEnumerable>)(source =>
        {
            var qry = source;
            if (condition1)
            {
                qry = qry.Cast<string>().Where(x => x.Length > 3);
            }
            if (condition2)
            {
                qry = qry.Cast<int>().Where(x => x < 10);
            }
            if (condition3)
            {
                return qry.Cast<string>().Select(x => x.Length);
            }
            return qry;
        });
        
        var result_v2_1 = fnc(arrayOne);
        var result_v2_2 = fnc(arrayTwo);

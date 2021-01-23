    foreach (var item in row.ItemArray) // Loop over the items.
        {
            int i;
            for (i = 1; i < 30; i++)
            {
                excell_app.createHeaders(1, 1, "" + item + "", i, i, 1, "black", false, 10, "n");
            }
            Console.WriteLine(i);
        }

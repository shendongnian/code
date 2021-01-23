        for (int i = 0; i < TotalNumberAdded; i++)
        {
            AddControls(i + 1);
        }
        for (int i = 0; i < TotalNumberSolAdded; i++)
        {
            AddMoreControls((i + 1), 1);
            DataTable dt = (DataTable)ViewState["t"];
            if (dt != null)
            {
                if ((TotalNumberSolAdded - dt.Rows.Count == 1) && (counter1 == dt.Rows.Count))
                {
                    break;
                }
                if (i != 0)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        int a1 = int.Parse(dt.Rows[k][0].ToString());
                        b = a1 + b;
                    }
                    start = b - int.Parse(dt.Rows[i][0].ToString());
                }
                else
                {
                    b = int.Parse(dt.Rows[i][0].ToString());
                    start = 0;
                }
                for (int j = start; j < b; j++)
                {
                    counter++;
                    AddMoreStepControls((j + 1), counter);
                }
                b = 0;
                counter = 0;
                counter1++;
            }
        }
    }

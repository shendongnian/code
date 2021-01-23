        static void dtSP_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            bool temp = false;
            try
            {
                temp = e.Row[4, DataRowVersion.Original] == e.Row[4];
            }
            catch { }
            if (temp && int.Parse(e.Row[3].ToString()) != -1)
            {
                e.Row[4] = (/* my logic */);
            }
        }

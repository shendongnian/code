     private void rnd(int iter, int posinicio)
     {
        for (int iterador = 0; iterador < iter; iterador++)
        {
            System.Data.DataRow dr = ds.Tables["Out"].NewRow();
            dr["Value1"] = vals[iterador + posinicio].Value1;
            dr["Value2"] = vals[iterador + posinicio].Value2;
            lock (myLock)
            {
                ds.Tables["Out"].Rows.Add(dr);
            }
        }
    }

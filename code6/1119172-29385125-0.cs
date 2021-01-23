    try
    {
    
        DRorder = getlist.ExecuteReader();
        while (DRorder.Read())
        {
            Console.WriteLine("BESTEL: " + DRorder.GetOrdinal("BESTEL").ToString());
            Console.WriteLine("PLAN: " + DRorder.GetOrdinal("PLAN").ToString());
            Console.WriteLine("ADRES: " + DRorder.GetOrdinal("ADRES").ToString());
            Console.WriteLine("LEV: " + DRorder.GetOrdinal("LEV").ToString());
            Console.WriteLine("TAAL: " + DRorder.GetOrdinal("TAAL").ToString());
            if (!DRorder.IsDBNull(10)) { dateTimePicker1.Value = Convert.ToDateTime(DRorder[10]); }
            if (!DRorder.IsDBNull(11)) { dateTimePicker2.Value = Convert.ToDateTime(DRorder[11]); }
            if (!DRorder.IsDBNull(7)) { comboBox1.Text = DRorder[7].ToString(); }
            if (!DRorder.IsDBNull(8)) { comboBox2.Text = DRorder[8].ToString(); }
            if (!DRorder.IsDBNull(25)) { textBox8.Text = DRorder[25].ToString(); }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }

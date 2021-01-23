     SqlParameter parameter = new SqlParameter("@Price", SqlDbType.Decimal);
     parameter.Precision = 18;
     parameter.Scale = 0;
     parameter.Value = textBox3.Text;
    cm.Parameters.Add(parameter);

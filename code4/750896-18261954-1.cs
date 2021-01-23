     SqlCeParameter parameter = new SqlCeParameter();
     parameter.SqlDbType = SqlDbType.Decimal;
     parameter.Precision = 18;
     parameter.Scale = 0;
     parameter.Value = textBox3.Text;
    cm.Parameters.Add(parameter);

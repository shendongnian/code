    public List<Object[]> Rows()
        {
            List<Object[]> list = new List<Object[]>();
            Cn.Open();
            Dr = Cmd.ExecuteReader();
            while (Dr.Read())
            {
                Object[] array = new Object[Dr.FieldCount];
                Dr.GetValues(array);
                list.Add(array);
            }
            return list;
        }

            StringBuilder sb = new StringBuilder("Id IN(");
            List<SqlParameter> parameters = new List<SqlParameter>();
            int i = 1;
            foreach (int item in items)
            {
                string currentItem = "@Item" + i++.ToString();
                sb.Append(currentItem + ",");
                parameters.Add(new SqlParameter(currentItem , item));
            }
            sb.Remove(sb.Length-1, 1);
            sb.Append(")");

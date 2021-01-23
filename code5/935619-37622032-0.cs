        public static List<T> ToList<T>(this DataGridViewSelectedRowCollection rows)
        {
            var list = new List<T>();
            for (int i = 0; i < rows.Count; i++)
                list.Add((T)rows[i].DataBoundItem);
            return list;
        }

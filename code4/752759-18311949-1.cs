        public String getQuerySelectInner(String TABELA, params Dictionary<String, String>[] dictionaries)
        {
            String sql = "SELECT ";
            foreach (var dictionary in dictionaries)
            {
                foreach (var word in dictionary)
                {
                    sql += word.Key + ",";
                }
            }
            sql = sql.Remove(sql.Length - 1);
            sql += " from " + TABELA + "  WHERE situacao = 'ATIVO' ";
            return sql;
        }

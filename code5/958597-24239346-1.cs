            if (!string.IsNullOrEmpty(condition)/* && !string.IsNullOrEmpty(condition2)*/)
            {
                condition = string.Format(" where Eis IN ({0}) GROUP BY Systeem HAVING count(*) = {1}", condition.Substring(0, condition.Length - 2), numSelected/*, condition2.Substring(0, condition2.Length - 2)*/);
            }
            string orderBy = string.Format(" ORDER BY count(*)");
            SqlCommand cmd = new SqlCommand(query + condition + orderBy);        

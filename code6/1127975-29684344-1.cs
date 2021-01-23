	StringBuilder sb = new StringBuilder();
	for (int i = 0; i < DataAccess.Instance.tabelafinal5.Rows.Count; i++)
	{
		bool isFirst = true;
		sb.Clear();
		for (int y = 2; y < listadecolunas.Count; y++)
		{
			string elemento0 = DataAccess.Instance.tabelafinal5.Rows[i][y].ToString();
			if (elemento0 != "")
			{
				if(isFirst)
				{
					isFirst = false;
				}
				else
				{
					sb.Append(" + ")
				}
				sb.Append(elemento0);
			}
		}
		if(sb.Length > 0)
		{
		DataAccess.Instance.tabelafinal5.Rows[i]["Expressão"] = DataAccess.Instance.tabelafinal5.Rows[i]["Expressão"] + sb.ToString();
		}
	} 

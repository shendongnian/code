    var query = "SELECT [Description], [Price] FROM [Data] WHERE [Code] IN (";
     if (int.TryParse(this.textBoxCodeContainer[0][0].Text, out codeValue))
     {
     query = query + codeValue.ToString();
     }
     if (int.TryParse(this.textBoxCodeContainer[0][1].Text, out codeValue))
     {
     query = query + "," + codeValue.ToString();
     }
     query = query + ")";
     OleDbCommand cmd = new OleDbCommand(query, conn);
     dReader = cmd.ExecuteReader();

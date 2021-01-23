      var t = new DataTable();
      // create column header
      foreach ( string s in identifiders ) {
        t.Columns.Add(new DataColumn(s)); // <<=== i'm expecting you don't have defined any DataColumns, haven't you?
      }
      // Add data to DataTable
      for ( int lineNumber = identifierLineNumber; lineNumber < lineCount; lineNumber++ ) {
        DataRow newRow = t.NewRow();
        for ( int column = 0; column < identifierCount; column++ ) {
          newRow[column] = fileContent.ElementAt(lineNumber)[column];
        }
        t.Rows.Add(newRow);
      }
      return t.DefaultView;

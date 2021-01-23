    Public Shared Function bulkQuery()
    
            Dim query As StringBuilder = New StringBuilder
    
            query.Append("USE Import_DB BULK INSERT dbo.[Insert_Table] FROM")
            query.Append(" 'C:\Insert_Table.csv' ")
            query.Append("With (FIELDTERMINATOR = ',', ROWTERMINATOR = '\n')")
    
            Return query.ToString
    
        End Function

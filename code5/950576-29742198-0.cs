    Imports System.Collections
    'Imports System.Configuration
    
    Public Class DatabaseLogic
        Public ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("db").ToString()
    
        Public Function ServerDataMagic(StoredProcedure As String, PDMdata As Hashtable) As DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(ConnectionString )  'Here  I am getting error.
            Using cmd As DbCommand = db.GetStoredProcCommand(StoredProcedure)
                Try
                    db.DiscoverParameters(cmd)
                Catch discover_ex As Exception
    
                End Try

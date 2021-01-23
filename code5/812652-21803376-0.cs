    Imports System.Reflection
    Imports System.Runtime.CompilerServices
    Imports System.Data.Services.Providers
    
    Public Module EntityFrameworkDataServiceProvider2Extensions
       
        ''' <summary>
        ''' Gets the underlying data model currently used by an EntityFrameworkDataServiceProvider2.
        ''' </summary>
        ''' <remarks>
        ''' TODO: Obsolete this method if the API changes to support access to the model.
        ''' Reflection is used as a workaround because EntityFrameworkDataServiceProvider2 doesn't (yet) provide access to its underlying data source. 
        ''' </remarks>
        <System.Runtime.CompilerServices.Extension> _
        Public Function GetDataModel(Of T As Class)(efProvider As EntityFrameworkDataServiceProvider2(Of T)) As T
            If efProvider IsNot Nothing Then
                Dim modelType As Type = GetType(T)
    
                ' Get the innerProvider field info for an EntityFrameworkDataServiceProvider2 of the requested type
                Dim ipField As FieldInfo = Nothing
                If Not InnerProviderFieldInfoCache.TryGetValue(modelType, ipField) Then
                    ipField = efProvider.[GetType]().GetField("innerProvider", BindingFlags.NonPublic Or BindingFlags.Instance)
                    InnerProviderFieldInfoCache.Add(modelType, ipField)
                End If
    
                Dim innerProvider = ipField.GetValue(efProvider)
                If innerProvider IsNot Nothing Then
                    ' Get the CurrentDataSource property of the innerProvider
                    Dim cdsProperty As PropertyInfo = Nothing
                    If Not CurrentDataSourcePropertyInfoCache.TryGetValue(modelType, cdsProperty) Then
                        cdsProperty = innerProvider.[GetType]().GetProperty("CurrentDataSource")
                        CurrentDataSourcePropertyInfoCache.Add(modelType, cdsProperty)
                    End If
                    Return TryCast(cdsProperty.GetValue(innerProvider, Nothing), T)
                End If
            End If
            Return Nothing
        End Function
    
        Private ReadOnly InnerProviderFieldInfoCache As New ConditionalWeakTable(Of Type, FieldInfo)()
        Private ReadOnly CurrentDataSourcePropertyInfoCache As New ConditionalWeakTable(Of Type, PropertyInfo)()
    End Module

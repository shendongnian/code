    Public Class Item
        Public Property id As Integer
        Public Property name As String
        Public Property path_from_root As NameValuePair()
        Public Property children_categories As NameValuePair()
        Public Property attributes_required As Boolean
        Public Property max_pictures_per_item As Integer
        Public Property max_title_length As Integer
        Public Property max_price As Object
        Public Property min_price As Object
        Public Property listing_allowed As Boolean
    End Class
    
    Public Class NameValuePair
        Public Property id As Integer
        Public Property name As String
    End Clas
    ...
    Dim jstr As String = from whereever
    Dim jd = JsonConvert.DeserializeObject(Of Dictionary(Of Integer, Item))(jstr)

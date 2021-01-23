    Public Module MyExtensions
        <System.Runtime.CompilerServices.Extension()> _
        Public Function [Get](Of T)(view As ListView, ParamArray members As String()) As List(Of T)
            Dim list As New List(Of ListViewItem)
            For Each item As ListViewItem In view.Items
                list.Add(item)
            Next
            Return list.Get(Of T)(members)
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function [Get](Of T)(item As ListViewItem, ParamArray members As String()) As List(Of T)
            Return New ListViewItem() {item}.Get(Of T)(members)
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function [Get](Of T)(collection As IEnumerable(Of ListViewItem), ParamArray members As String()) As List(Of T)
            Dim list As New List(Of T)
            Dim length As Integer = (members.Length - 1)
            If (length > -1) Then
                Dim type As Type = GetType(T)
                Dim info As KeyValuePair(Of MemberInfo, Type)() = New KeyValuePair(Of MemberInfo, Type)(length) {}
                For index As Integer = 0 To length
                    For Each m As MemberInfo In type.GetMember(members(index), (MemberTypes.Method Or MemberTypes.Property), (BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly))
                        If (m.MemberType = MemberTypes.Property) Then
                            With DirectCast(m, PropertyInfo)
                                If (.CanWrite AndAlso (.GetIndexParameters().Length = 0)) Then
                                    info(index) = New KeyValuePair(Of MemberInfo, Type)(m, .PropertyType)
                                    Exit For
                                End If
                            End With
                        ElseIf (m.MemberType = MemberTypes.Method) Then
                            With DirectCast(m, MethodInfo)
                                Dim params As ParameterInfo() = .GetParameters()
                                If (params.Length = 1) Then
                                    info(index) = New KeyValuePair(Of MemberInfo, Type)(m, params(0).ParameterType)
                                    Exit For
                                End If
                            End With
                        End If
                    Next
                Next
                For Each item As ListViewItem In collection
                    Dim obj As T = Activator.CreateInstance(Of T)()
                    Dim ict As Type = GetType(IConvertible)
                    For index As Integer = 0 To length
                        Dim pair As KeyValuePair(Of MemberInfo, Type) = info(index)
                        If (Not pair.Key Is Nothing) Then
                            If (ict.IsAssignableFrom(pair.Value)) Then
                                If (pair.Key.MemberType = MemberTypes.Property) Then
                                    DirectCast(pair.Key, PropertyInfo).SetValue(obj, System.Convert.ChangeType(item.SubItems(index).Text, pair.Value), Nothing)
                                Else
                                    DirectCast(pair.Key, MethodInfo).Invoke(obj, System.Convert.ChangeType(item.SubItems(index).Text, pair.Value))
                                End If
                            Else
                                'TODO: Support other data types.
                                'If (pair.Key.MemberType = MemberTypes.Property) Then
                                'DirectCast(pair.Key, PropertyInfo).SetValue(obj, item.SubItems(index).Text, Nothing)
                                'Else
                                'DirectCast(pair.Key, MethodInfo).Invoke(obj, New Object() {item.SubItems(index).Text})
                                'End If
                            End If
                        End If
                    Next
                    list.Add(obj)
                Next
            End If
            Return list
        End Function
    End Module

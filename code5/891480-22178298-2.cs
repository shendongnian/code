     Protected Sub CustomersGridView_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
    
            ' Retrieve the pager row.
            Dim pagerRow As GridViewRow = gridUsers.BottomPagerRow
    
            'Retrieve the PageDropDownList DropDownList from the bottom pager row.
            Dim pageList As DropDownList = DirectCast(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
    
            Dim pageLabel As Label = DirectCast(pagerRow.Cells(0).FindControl("CurrentPageLabel"), Label)
    
            If pageList IsNot Nothing Then
    
                For i As Integer = 0 To gridUsers.PageCount
    
                    Dim pageNumber As Integer = i + 1
                    Dim item As New ListItem(pageNumber.ToString())
    
    
                    If i = gridUsers.PageIndex Then
    
                        item.Selected = True
                    End If
    
                    pageList.Items.Add(item)
                Next
    
            End If
    
            If pageLabel IsNot Nothing Then  
                Dim currentPage As Integer = gridUsers.PageIndex + 1
                pageLabel.Text = "Page " + currentPage.ToString() + " of " + gridUsers.PageCount.ToString()
    
            End If
        End Sub

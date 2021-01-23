	Public Module ControlUtilities
		<Extension()>
		Public Sub CustomPager(ByRef grd As GridView)
			Dim cp As New clsCustomPager(grd)
		End Sub
		Public Class clsCustomPager
			Public _grd As GridView
			Public Property rpt() As GridView
				Get
					Return _grd
				End Get
				Set(value As GridView)
					_grd = value
				End Set
			End Property
			Public Sub New(ActiveGridView As GridView)
				_grd = ActiveGridView
				Me.CustomPages()
			End Sub
			''' <summary>
			''' create the objects needed for a bootstrap driven navigation for a gridview
			''' </summary>
			Sub CustomPages()
				If Not _grd Is Nothing And Not _grd.BottomPagerRow Is Nothing Then
					'hook event handler to grid
					AddHandler _grd.PageIndexChanging, AddressOf Me.Grid_PageIndexChanging
					'declare variables
					Dim pagerRow As GridViewRow = _grd.BottomPagerRow
					Dim lnkPrev As LinkButton = New LinkButton()
					Dim lnkNext As LinkButton = New LinkButton()
					'set up previous link
					lnkPrev.CommandArgument = "Prev"
					lnkPrev.CommandName = "Page"
					lnkPrev.Text = "<span>&laquo;</span>"
					'set up next link
					lnkNext.CommandArgument = "Next"
					lnkNext.CommandName = "Page"
					lnkNext.Text = "<span>&raquo;</span>"
					'create html unordered list
					pagerRow.Cells(0).Controls.Add(New LiteralControl("<ul class=""pagination"">"))
					'add previous link
					pagerRow.Cells(0).Controls.Add(New LiteralControl("<li>"))
					pagerRow.Cells(0).Controls.Add(lnkPrev)
					pagerRow.Cells(0).Controls.Add(New LiteralControl("</li>"))
					Dim pageNumber As Integer
					For Each pageNumber In Enumerable.Range(1, _grd.PageCount)
						'create page link object
						Dim lnkPage As LinkButton = New LinkButton()
						lnkPage.CommandName = "Page"
						lnkPage.Text = pageNumber
						lnkPage.CommandArgument = (pageNumber - 1)
						AddHandler lnkPage.Click, AddressOf Me.lnkPageNumber_Click 'event handler
						'set css class if selected or not
						If (pageNumber - 1) = _grd.PageIndex Then
							pagerRow.Cells(0).Controls.Add(New LiteralControl("<li class=""active"">"))
						Else
							pagerRow.Cells(0).Controls.Add(New LiteralControl("<li>"))
						End If
						'add lnk and close html listitem
						pagerRow.Cells(0).Controls.Add(lnkPage)
						pagerRow.Cells(0).Controls.Add(New LiteralControl("</li>"))
					Next
					'add next link
					pagerRow.Cells(0).Controls.Add(New LiteralControl("<li>"))
					pagerRow.Cells(0).Controls.Add(lnkNext)
					pagerRow.Cells(0).Controls.Add(New LiteralControl("</li>"))
					'close up unordered list
					pagerRow.Cells(0).Controls.Add(New LiteralControl("</ul>"))
				End If
			End Sub
			''' <summary>
			''' event handler for previous/next buttons
			''' </summary>
			Protected Sub Grid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
				If e.NewPageIndex >= 0 Then
					_grd.PageIndex = e.NewPageIndex
					_grd.DataBind()
					Me.CustomPages()
				End If
			End Sub
			''' <summary>
			''' event handler for numeric link buttons
			''' </summary>
			Protected Sub lnkPageNumber_Click(sender As Object, e As EventArgs)
				Dim btn As LinkButton = DirectCast(sender, LinkButton)
				_grd.PageIndex = btn.CommandArgument
				_grd.DataBind()
				Me.CustomPages()
			End Sub
		End Class
	End Module

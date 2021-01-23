	Imports Microsoft.SharePoint.Client
	Module Main
		Sub main()
			Dim context As New ClientContext("<<YOUR SHAREPOINT URL>>")
			Dim webcontent As Web = context.Web
			Dim weblist As ListCollection = context.Web.Lists
			context.Load(weblist)
			context.ExecuteQuery()
			Dim testList As List = context.Web.Lists.GetByTitle("<<YOUR SHAREPOINT LIBRARY>>")
			Dim query As CamlQuery = CamlQuery.CreateAllItemsQuery()
			Dim items As ListItemCollection = testList.GetItems(query)
			context.Load(items)
			context.ExecuteQuery()
			For Each listItem As ListItem In items
				Dim myJobName = listItem.FieldValues("JobName")
				If Not myJobName Is Nothing Then
					Dim myDownload As FileInformation
					Dim myOutFile As String = "C:\test\"
					Dim myModDt = Date.Parse(listItem.FieldValues("Modified").ToString).ToString("yyyyMMdd")
					myDownload = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, listItem("FileRef").ToString)
					myOutFile += myJobName & "_" & myModDt & ".xls"
					Dim fileStream As Object = System.IO.File.Create(myOutFile)
					myDownload.Stream.CopyTo(fileStream)
				End If
			Next
		End Sub
	End Module

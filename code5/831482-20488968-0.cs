    For Each page As PdfPage In document.Pages
    	' Get resources dictionary
    	Dim resources As PdfDictionary = page.Elements.GetDictionary("/Resources")
    	If resources IsNot Nothing Then
    		' Get external objects dictionary
    		Dim xObjects As PdfDictionary = resources.Elements.GetDictionary("/XObject")
    		If xObjects IsNot Nothing Then
    			Dim items As ICollection(Of PdfItem) = xObjects.Elements.Values
    			' Iterate references to external objects
    			For Each item As PdfItem In items
    				Dim reference As PdfReference = TryCast(item, PdfReference)
    				If reference IsNot Nothing Then
    					Dim xObject As PdfDictionary = TryCast(reference.Value, PdfDictionary)
    					' Is external object an image?
    					If xObject IsNot Nothing AndAlso xObject.Elements.GetString("/Subtype") = "/Image" Then
    						ExportImage(xObject, imageCount)
    					End If
    				End If
    			Next
    		End If
    	End If
    Next

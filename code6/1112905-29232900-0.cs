    Dim pivotItems As Object = New ExpandoObject()
        ' set properties for object'
         pivotItems.Quarter = developmentQuarters.Key
         pivotItems.Name = developmentQuarters.Key.Name
         ' since expando obj is a dictionary for prop name and its value we can set property names dynamically like this'
         For Each developmentModel As DevelopmentModel In developmentModels
             Dim pivotAsDict As IDictionary(Of String, Object) = pivotItems
             pivotAsDict.Add(developmentModel.BusinessGroupName + " " + developmentModel.Currency.Code, developmentModel.DevelopmentPercentage)
          Next
          ReModelledItems.Add(pivotItems)

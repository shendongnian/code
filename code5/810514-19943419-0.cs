			employeeQuery.IncludeRetElementList.Add("DataExtRet");
			employeeQuery.OwnerIDList.Add("0");
			for (int x = 0; x < employee.DataExtRetList.Count; x++)
			{
				// get the dataExt object, now you have access to the custom field
				IDataExtRet dataExt = employee.DataExtRetList.GetAt(x);
				string customFieldName = dataExt.DataExtName.GetValue();
				string value = dataExt.DataExtValue.GetValue();
			}

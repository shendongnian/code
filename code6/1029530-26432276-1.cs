            var oOldRecord = new EmployeeMasterHistory();
            oOldRecord.EmployeeNumber = 1;
            var oNewRecord = new EmployeeMasterHistory();
            oNewRecord.EmployeeNumber = 2;
            oNewRecord.CompanyNumber = 3;
            var oType = oOldRecord.GetType();
            foreach (var oProperty in oType.GetProperties())
            {
                var oOldValue = oProperty.GetValue(oOldRecord, null);
                var oNewValue = oProperty.GetValue(oNewRecord, null);
                // this will handle the scenario where either value is null
                if (!object.Equals(oOldValue, oNewValue))
                {
                    // Handle the display values when the underlying value is null
                    var sOldValue = oOldValue == null ? "null" : oOldValue.ToString();
                    var sNewValue = oNewValue == null ? "null" : oNewValue.ToString();
                    System.Diagnostics.Debug.WriteLine("Property " + oProperty.Name + " was: " + sOldValue + "; is: " + sNewValue);
                }
            }

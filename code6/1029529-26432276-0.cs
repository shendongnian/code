            var oOldRecord = new EmployeeMasterHistory();
            oOldRecord.EmployeeNumber = 1;
            var oNewRecord = new EmployeeMasterHistory();
            oNewRecord.EmployeeNumber = 2;
            var oType = oOldRecord.GetType();
            foreach (var oProperty in oType.GetProperties())
            {
                var oOldValue = oProperty.GetValue(oOldRecord, null);
                var oNewValue = oProperty.GetValue(oNewRecord, null);
                if ((oOldValue != null) && (oNewValue != null))
                {
                    if (!oOldValue.Equals(oNewValue))
                    {
                        System.Diagnostics.Debug.WriteLine("Property " + oProperty.Name + " was: " + oOldValue.ToString() + "; is: " + oNewValue.ToString());
                    }
                }
            }

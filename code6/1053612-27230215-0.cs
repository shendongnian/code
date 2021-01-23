     //creating a fake table, use the one you have
                DataTable fakeTable = new DataTable();
                fakeTable.Columns.Add(new DataColumn("Name",typeof(string)));
                fakeTable.Rows.Add(new object[]{"John Doe"});
                DataRow r= fakeTable.Rows[0];
                
                //change to the type of the field you want to retrieve from the data row
                var myType = typeof(string);
                //change to the column name you want retrieve from the data row
                var columnName = "Name";
    
                //getting the extensor method T DataRowExtensions.Field<T>(this DataRow dr,string columnName)
                MethodInfo genericMethod = typeof(DataRowExtensions).GetMethod("Field", new Type[] { typeof(DataRow), typeof(string) });
                MethodInfo method = genericMethod.MakeGenericMethod(myType);
                //as the extensor method is static, instance is not need so just pass null
                var result = method.Invoke(null,new object[]{ r, columnName});
    
                Console.WriteLine(result);

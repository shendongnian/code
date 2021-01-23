           public void CheckDataSet(DataSet dataSet)
           {                                                              
            Assembly assembly = Assembly.LoadFrom(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Data.dll");
            Type type = assembly.GetType("System.Data.ConstraintEnumerator");
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(DataSet) });
            object instance = ctor.Invoke(new object[] { dataSet });                
            BindingFlags bf = BindingFlags.Instance | BindingFlags.Public;
            MethodInfo m_GetNext = type.GetMethod("GetNext", bf);
                
            while ((bool)m_GetNext.Invoke(instance, null))
            {
                bool flag = false;
                MethodInfo m_GetConstraint = type.GetMethod("GetConstraint", bf);                    
                Constraint constraint = (Constraint) m_GetConstraint.Invoke(instance, null);
                Type constraintType = constraint.GetType();
                BindingFlags bfInternal = BindingFlags.Instance | BindingFlags.NonPublic;
                MethodInfo m_IsConstraintViolated = constraintType.GetMethod("IsConstraintViolated", bfInternal);                    
                flag = (bool)m_IsConstraintViolated.Invoke(constraint, null);
                if (flag)                    
                    Debug.WriteLine("Constraint violated, ConstraintName: " + constraint.ConstraintName + ", tableName: " + constraint.Table);                                            
            }
                
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Type columnType = column.GetType();
                    BindingFlags bfInternal = BindingFlags.Instance | BindingFlags.NonPublic;
                    bool flag = false;
                    if (!column.AllowDBNull)
                    {                            
                        MethodInfo m_IsNotAllowDBNullViolated = columnType.GetMethod("IsNotAllowDBNullViolated", bfInternal);                                                        
                        flag = (bool)m_IsNotAllowDBNullViolated.Invoke(column, null);
                        if (flag)
                        {
                            Debug.WriteLine("DBnull violated  --> ColumnName: " + column.ColumnName + ", tableName: " + column.Table.TableName);
                        }
                    }
                    if (column.MaxLength >= 0)
                    {
                        MethodInfo m_IsMaxLengthViolated = columnType.GetMethod("IsMaxLengthViolated", bfInternal);                            
                        flag = (bool)m_IsMaxLengthViolated.Invoke(column, null);                            
                        if (flag)                            
                            Debug.WriteLine("MaxLength violated --> ColumnName: " + column.ColumnName + ", tableName: " + column.Table.TableName);
                    }
                }
            }                                                    
    }

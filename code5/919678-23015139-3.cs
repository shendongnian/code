    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ output extension=".cs" #>
    using System;
    using System.Data;
    namespace MyApp
    {
        public static class SomeMagicDataHelper
        {
            public static bool TrySetValue(DataRow dataRow, DataColumn dataColumn, object value)
            {
                try
                {
                    if (value == null)
                    {
                        if (!dataColumn.AllowDBNull)
                            return false;
                        else
                        {
                            dataRow[dataColumn] = DBNull.Value;
                            return true;
                        }
                    }
                    // if the types match exactly, a direct assignment will work
                    if (value.GetType() == dataColumn.DataType)
                    {
                        dataRow[dataColumn] = value;
                        return true;
                    }
                    // otherwise, we'll do a TryParse
                    switch (dataColumn.DataType.FullName)
                    {
                        case "<#= typeof(string).FullName #>":
                            dataRow[dataColumn] = value;
                            return true;
                        case "<#= typeof(byte[]).FullName #>":
                            return false;
    <# foreach (var type in new[] { typeof(Boolean), typeof(Byte), typeof(Char), typeof(DateTime), typeof(Decimal), typeof(Double), typeof(Guid), typeof(Int16), typeof(Int32), typeof(Int64), typeof(SByte), typeof(Single), typeof(TimeSpan), typeof(UInt16), typeof(UInt32), typeof(UInt64) }) {
    #>                    case "<#= type.FullName #>":
                        {
                            <#= type.Name #> tryValue;
                            if (<#= type.Name #>.TryParse(value.ToString(), out tryValue))
                            {
                                dataRow[dataColumn] = tryValue;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
    <# } #>
                    }
                    // last resort, might throw an exception
                    dataRow[dataColumn] = value;
                    return true;
                }
                catch (Exception ex)
                {
                    // log ex, this shouldn't be a common thing
                    return false;
                }
            }
        }
    }

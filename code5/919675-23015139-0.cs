	<#@ template debug="false" hostspecific="false" language="C#" #>
	<#@ assembly name="System.Core" #>
	<#@ import namespace="System.Linq" #>
	<#@ import namespace="System.Text" #>
	<#@ import namespace="System.Collections.Generic" #>
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
					var valueType = value.GetType();
					if (dataColumn.DataType == typeof(string))
					{
						dataRow[dataColumn] = value;
						return true;
					}
					else if (dataColumn.DataType == typeof(byte[]))
					{
						if (valueType == typeof(byte[]))
						{
							dataRow[dataColumn] = value;
							return true;
						}
						return false;
					}
		<# foreach (var type in new[] { "Boolean", "Byte", "Char", "DateTime", "Decimal", "Double", "Guid", "Int16", "Int32", "Int64", "SByte", "Single", "TimeSpan", "UInt16", "UInt32", "UInt64" }) {
		#>            else if (dataColumn.DataType == typeof(<#= type #>))
					{
						<#= type #> tryValue;
						if (<#= type #>.TryParse(value.ToString(), out tryValue))
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

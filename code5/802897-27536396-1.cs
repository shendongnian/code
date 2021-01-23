    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Text;
    using System.Xml;
    
    namespace ClientUtil
    {
    public class DataTableUtil
    {
    
    public static string DataTableToXmlString(DataTable dtData)
    {
    if (dtData == null || dtData.Columns.Count == 0)
    return (string) null;
    DataColumn[] primaryKey = dtData.PrimaryKey;
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(“<TABLE>”);
    stringBuilder.Append(“<TR>”);
    foreach (DataColumn dataColumn in (InternalDataCollectionBase) dtData.Columns)
    {
    if (DataTableUtil.IsPrimaryKey(dataColumn.ColumnName, primaryKey))
    stringBuilder.Append(“<TH IsPK=’true’ ColType='”).Append(Convert.ToString(dataColumn.DataType == typeof (object) ? (object) typeof (string) : (object) dataColumn.DataType)).Append(“‘>”).Append(dataColumn.ColumnName.Replace(“&”, “”)).Append(“</TH>”);
    else
    stringBuilder.Append(“<TH IsPK=’false’ ColType='”).Append(Convert.ToString(dataColumn.DataType == typeof (object) ? (object) typeof (string) : (object) dataColumn.DataType)).Append(“‘>”).Append(dataColumn.ColumnName.Replace(“&”, “”)).Append(“</TH>”);
    }
    stringBuilder.Append(“</TR>”);
    int num1 = 0;
    foreach (DataRow dataRow in (InternalDataCollectionBase) dtData.Rows)
    {
    stringBuilder.Append(“<TR>”);
    int num2 = 0;
    foreach (DataColumn dataColumn in (InternalDataCollectionBase) dtData.Columns)
    {
    string str = Convert.IsDBNull(dataRow[dataColumn.ColumnName]) ? (string) null : Convert.ToString(dataRow[dataColumn.ColumnName]).Replace(“<“, “&lt;”).Replace(“>”, “&gt;”).Replace(“\””, “&quot;”).Replace(“‘”, “&apos;”).Replace(“&”, “&amp;”);
    if (!string.IsNullOrEmpty(str))
    stringBuilder.Append(“<TD>”).Append(str).Append(“</TD>”);
    else
    stringBuilder.Append(“<TD>”).Append(“</TD>”);
    ++num2;
    }
    stringBuilder.Append(“</TR>”);
    ++num1;
    }
    stringBuilder.Append(“</TABLE>”);
    return ((object) stringBuilder).ToString();
    }
    
    protected static bool IsPrimaryKey(string ColumnName, DataColumn[] PKs)
    {
    if (PKs == null || string.IsNullOrEmpty(ColumnName))
    return false;
    foreach (DataColumn dataColumn in PKs)
    {
    if (dataColumn.ColumnName.ToLower().Trim() == ColumnName.ToLower().Trim())
    return true;
    }
    return false;
    }
    
    public static DataTable XmlStringToDataTable(string XmlData)
    {
    DataTable dataTable = (DataTable) null;
    IList<DataColumn> list = (IList<DataColumn>) new List<DataColumn>();
    if (string.IsNullOrEmpty(XmlData))
    return (DataTable) null;
    XmlDocument xmlDocument1 = new XmlDocument();
    xmlDocument1.PreserveWhitespace = true;
    XmlDocument xmlDocument2 = xmlDocument1;
    xmlDocument2.LoadXml(XmlData);
    XmlNode xmlNode1 = xmlDocument2.SelectSingleNode(“/TABLE”);
    if (xmlNode1 != null)
    {
    dataTable = new DataTable();
    int num = 0;
    foreach (XmlNode xmlNode2 in xmlNode1.SelectNodes(“TR”))
    {
    if (num == 0)
    {
    foreach (XmlNode xmlNode3 in xmlNode2.SelectNodes(“TH”))
    {
    bool result = false;
    string str = xmlNode3.Attributes[“IsPK”].Value;
    if (!string.IsNullOrEmpty(str))
    {
    if (!bool.TryParse(str, out result))
    result = false;
    }
    else
    result = false;
    Type type = Type.GetType(xmlNode3.Attributes[“ColType”].Value);
    DataColumn column = new DataColumn(xmlNode3.InnerText, type);
    if (result)
    list.Add(column);
    if (!dataTable.Columns.Contains(column.ColumnName))
    dataTable.Columns.Add(column);
    }
    if (list.Count > 0)
    {
    DataColumn[] dataColumnArray = new DataColumn[list.Count];
    for (int index = 0; index < list.Count; ++index)
    dataColumnArray[index] = list[index];
    dataTable.PrimaryKey = dataColumnArray;
    }
    }
    else
    {
    DataRow row = dataTable.NewRow();
    int index = 0;
    foreach (XmlNode xmlNode3 in xmlNode2.SelectNodes(“TD”))
    {
    Type dataType = dataTable.Columns[index].DataType;
    string s = xmlNode3.InnerText;
    if (!string.IsNullOrEmpty(s))
    {
    try
    {
    s = s.Replace(“&lt;”, “<“);
    s = s.Replace(“&gt;”, “>”);
    s = s.Replace(“&quot;”, “\””);
    s = s.Replace(“&apos;”, “‘”);
    s = s.Replace(“&amp;”, “&”);
    row[index] = Convert.ChangeType((object) s, dataType);
    }
    catch
    {
    if (dataType == typeof (DateTime))
    row[index] = (object) DateTime.ParseExact(s, “yyyyMMdd”, (IFormatProvider) CultureInfo.InvariantCulture);
    }
    }
    else
    row[index] = Convert.DBNull;
    ++index;
    }
    dataTable.Rows.Add(row);
    }
    ++num;
    }
    }
    return dataTable;
    }
    }
    }

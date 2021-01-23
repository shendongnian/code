    private Cell CreateCellRow(object value)
    {
        Cell cell = new Cell();
        cell.CellReference = GetCellLocation();
        IncreaseCellColumn();
        if (value == null)
        {
            cell.DataType = CellValues.InlineString;
            cell.InlineString = new InlineString
            {
                Text = new Text("")
            };
            return cell;
        }
        
        switch (Type.GetTypeCode(value.GetType()))
        {
            case TypeCode.DateTime:
                cell.StyleIndex = 1;
                cell.CellValue = new CellValue(((DateTime)value).ToOADate().ToString(CultureInfo.InvariantCulture));
                break;
            case TypeCode.String:
                cell.DataType = CellValues.InlineString;
                cell.InlineString = new InlineString {Text = new Text((string) value)};
                break;
            case TypeCode.Boolean:
                cell.DataType = CellValues.Boolean;
                cell.CellValue = new CellValue((bool)value ? "1" : "0");
                break;
            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.SByte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
            case TypeCode.Decimal:
            case TypeCode.Double:
            case TypeCode.Single:
                cell.CellValue = new CellValue(((IFormattable)value).ToString(null, CultureInfo.InvariantCulture));
                break;
            default:
                throw new Exception("Unrecognized type: " + value.GetType().FullName);
        }
        return cell;
    }

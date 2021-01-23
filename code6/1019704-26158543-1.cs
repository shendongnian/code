    public class GeneratedClass
    {
        // Creates an Cell instance and adds its children.
        public Cell GenerateCell()
        {
            Cell cell1 = new Cell(){ CellReference = "A1", StyleIndex = (UInt32Value)1U };
            CellValue cellValue1 = new CellValue();
            cellValue1.Text = "3.4411042510946099E+17";
            cell1.Append(cellValue1);
            return cell1;
        }
    }

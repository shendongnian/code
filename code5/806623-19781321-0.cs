    protected void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        // Get the information about the column clicked
        var strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
        SortOrder strSortOrder = getSortOrder(e.ColumnIndex);
        // Sort the list
        StudentList.Sort(new StudentComparer(strColumnName, strSortOrder));
        
        // Rebind to use sorted list
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = StudentList;
        // Update user interface icon for sort order in column clicked
        dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
    }
    private SortOrder getSortOrder(int columnIndex)
    {
        if (dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
            dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
        {
            dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            return SortOrder.Ascending;
        }
        else
        {
            dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            return SortOrder.Descending;
        }
    }
    public class StudentComparer : IComparer<StudentRecord>
    {
        string memberName = String.Empty;
        SortOrder sortOrder = SortOrder.None;
        public StudentComparer(string strMemberName, SortOrder sortingOrder)
        {
            memberName = strMemberName;
            sortOrder = sortingOrder;
        }
        public int Compare(StudentRecord student1, StudentRecord student2)
        {
            int returnValue = 1;
            switch (memberName)
            {
                case "Name" :
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = student1.Name.CompareTo(student2.Name);
                    }
                    else
                    {
                        returnValue = student2.Name.CompareTo(student1.Name);
                    }
                    break;
                case "Age":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = student1.Age.CompareTo(student2.Age);
                    }
                    else
                    {
                        returnValue = student2.Age.CompareTo(student1.Age);
                    }
                    break;
                case "PhoneNum":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = student1.PhoneNum.CompareTo(student2.PhoneNum);
                    }
                    else
                    {
                        returnValue = student2.PhoneNum.CompareTo(student1.PhoneNum);
                    }
                    break;
                case "TestScore1":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = student1.TestScore1.CompareTo(student2.TestScore1);
                    }
                    else
                    {
                        returnValue = student2.TestScore1.CompareTo(student1.TestScore1);
                    }
                    break;
                case "TestScore1Date":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = student1.TestScore1Date.CompareTo(student2.TestScore1Date;
                    }
                    else
                    {
                        returnValue = student2.TestScore1Date.CompareTo(student1.TestScore1Date);
                    }
                    break;
                default:
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = Student1.Name.CompareTo(Student2.Name);
                    }
                    else
                    {
                        returnValue = Student2.Name.CompareTo(Student1.Name);
                    }
                    break;
            }
            return returnValue;
        }
    }

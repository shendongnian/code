    public class TimeAgoBoundField : System.Web.UI.WebControls.BoundField
    {
        public override bool ReadOnly
        {
            get { return true; }
        }
        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeCell(cell, cellType, rowState, rowIndex);
            if (cellType == DataControlCellType.DataCell)
            {
                cell.Controls.Add(new TimeAgoControl());
            }
        }
        protected override void OnDataBindField(object sender, EventArgs e)
        {
            if (sender is TableCell)
            {
                var cell = (TableCell)sender;
                var cellValue = this.GetValue(cell.NamingContainer);
                if (cellValue != null)
                {
                    var timeAgoControl = (TimeAgoControl) cell.Controls[0];
                    var dateTimeValue = (DateTime) cellValue;
                    var utcDateTime = dateTimeValue.Kind != DateTimeKind.Utc ? dateTimeValue.ToUniversalTime() : dateTimeValue;
                    timeAgoControl.ISO8601Timestamp = utcDateTime.ToString("s") + "Z";
                }
                else if (this.NullDisplayText != null)
                {
                    cell.Text = this.NullDisplayText;
                }
            }
        }
    }

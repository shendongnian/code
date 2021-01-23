        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RadGridView GridView = new RadGridView
            {
                AutoSizeRows = true,
                BeginEditMode = RadGridViewBeginEditMode.BeginEditProgrammatically,
                Location = new Point(0, 130),
                Name = "GridView",
                ShowRowErrors = false,
                Size = new Size(390, 100),
                TabIndex = 0,
                //Visible = false,
                Parent = this
            };
            GridView.Columns.AddRange(InitializeColumns().ToArray());
            List<OrderTripChangedAlertItem> list = new List<OrderTripChangedAlertItem>();
            OrderTripChangedAlertItem item = new OrderTripChangedAlertItem(0, "some info", "some type");
            list.Add(item);
            GridView.DataSource = list;
        }
        private List<GridViewTextBoxColumn> InitializeColumns()
        {
            var result = new List<GridViewTextBoxColumn>();
            {
                var columnId = new GridViewTextBoxColumn
                {
                    Name = "RecordID",
                    HeaderText = "ID",
                    FieldName = "RecordID",
                    MaxLength = 50,
                    Width = 50,
                    DataType = typeof(int)
                };
                result.Add(columnId);
            }
            {
                var columnInformation = new GridViewTextBoxColumn
                {
                    Name = "RecordInformation",
                    HeaderText = "Information",
                    FieldName = "RecordInformation",
                    MaxLength = 50,
                    Width = 250,
                    DataType = typeof(string)
                };
                result.Add(columnInformation);
            }
            {
                var columnRowType = new GridViewTextBoxColumn
                {
                    Name = "RecordType",
                    HeaderText = "Type",
                    FieldName = "RecordType",
                    MaxLength = 50,
                    Width = 250,
                    DataType = typeof(string)
                };
                result.Add(columnRowType);
            }
            return result;
        }
        internal class OrderTripChangedAlertItem
        {
            public int RecordID { get; set; }
            public string RecordInformation { get; set; }
            public string RecordType { get; set; }
            public OrderTripChangedAlertItem(int recordID, string recordInformation, string recordType)
            {
                RecordID = recordID;
                RecordInformation = recordInformation;
                RecordType = recordType;
            }
        }

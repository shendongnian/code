    using System;
    using System.Data;
    using Telerik.WinControls.UI;
     
    namespace example
    {
        public partial class frmtest : Telerik.WinControls.UI.RadForm
        {
            private DataTable _parentData = new DataTable();
     
            public frmtest()
            {
                InitializeComponent();
            }
     
            private void frmtest_Load(object sender, EventArgs e)
            {
                _parentData = exampleParentDataTableLoad(); // Replace with call to populate a datatable from a query
                loadGridAndParentRecords();
            }
     
            private void loadGridAndParentRecords()
            {
                exampleRadGridView.DataSource = _parentData;
                var _childTemplate = CreateChildTemplate();
                exampleRadGridView.Templates.Add(_childTemplate);
                _childTemplate.HierarchyDataProvider = new GridViewEventDataProvider(_childTemplate);
                exampleRadGridView.RowSourceNeeded += ExampleRadGridView_RowSourceNeeded;
            }
     
            private GridViewTemplate CreateChildTemplate()
            {
                GridViewTemplate template = new GridViewTemplate();
                template.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                template.Columns.Add(new GridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID"
                });
                template.Columns.Add(new GridViewTextBoxColumn
                {
                    Name = "SampleNumber",
                    HeaderText = "Sample Number"
                });
                template.Columns.Add(new GridViewTextBoxColumn
                {
                    Name = "ParentId",
                    HeaderText = "Parent Id"
                });
     
                return template;
            }
     
            private void ExampleRadGridView_RowSourceNeeded(object sender, Telerik.WinControls.UI.GridViewRowSourceNeededEventArgs e)
            {
                if (e.ParentRow != null)
                {
                    if (e.ParentRow.DataBoundItem is DataRowView rowViewData)
                    {
                        var _childDataTable = exampleChildTableLoad(); // Replace with call to populate a datatable from a query
     
                        var _dataRows = _childDataTable.Select($"ParentId = {rowViewData["Id"]}");
     
                        foreach (DataRow row in _dataRows)
                        {
                            GridViewRowInfo _newRowObj = e.Template.Rows.NewRow();
                            _newRowObj.Cells["Id"].Value = row["Id"];
                            _newRowObj.Cells["SampleNumber"].Value = row["SampleNumber"];
                            _newRowObj.Cells["ParentId"].Value = row["ParentId"];
                            e.SourceCollection.Add(_newRowObj);
                        }
                    }
                }
            }
     
            private DataTable exampleParentDataTableLoad()
            {
                DataTable _return = new DataTable();
                _return.Columns.Add("Id", typeof(int));
                _return.Columns.Add("DisplayName", typeof(string));
     
                _return.Rows.Add(1, "Test1");
                _return.Rows.Add(2, "Test2");
     
                return _return;
            }
     
            private DataTable exampleChildTableLoad()
            {
                DataTable _return = new DataTable();
                _return.Columns.Add("Id", typeof(int));
                _return.Columns.Add("SampleNumber", typeof(string));
                _return.Columns.Add("ParentId", typeof(int));
     
                _return.Rows.Add(9999, "Test1", 2);
                _return.Rows.Add(9998, "Test2", 2);
                _return.Rows.Add(9997, "Test3", 2);
                _return.Rows.Add(9996, "Test4", 1);
                _return.Rows.Add(9995, "Test5", 1);
                _return.Rows.Add(9994, "Test6", 1);
     
                return _return;
            }
        }
    }

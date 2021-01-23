    private void AddImageColumns()
    {
        RepositoryItemPictureEdit pictureEdit = this.PendingTaskGrid.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
        pictureEdit.SizeMode = PictureSizeMode.Zoom;
        PendingTaskGridView.OptionsView.AnimationType = GridAnimationType.AnimateAllContent;
        pictureEdit.NullText = " ";
        if (this.PendingTaskGridView.Columns.ColumnByName("StatusImage") == null)
        {
            this.PendingTaskGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = " ",
                Name = "StatusImage",
                FieldName = "StatusImage",
                Visible = true,
                UnboundType = DevExpress.Data.UnboundColumnType.Object,
                VisibleIndex = 0,
                Width = 25,
                MaxWidth = 25,
                ToolTip = "Task Status",
                ColumnEdit = pictureEdit
            });
        }
        if (this.PendingTaskGridView.Columns.ColumnByName("PunctualityImage") == null)
        {
            this.PendingTaskGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = " ",
                Name = "PunctualityImage",
                FieldName = "PunctualityImage",
                Visible = true,
                UnboundType = DevExpress.Data.UnboundColumnType.Object,
                VisibleIndex = 0,
                Width = 25,
                MaxWidth = 25,
                ToolTip = "Punctuality",
                ColumnEdit = pictureEdit
            });
        }
        if (this.PendingTaskGridView.Columns.ColumnByName("AttendanceImage") == null)
        {
            this.PendingTaskGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = " ",
                Name = "AttendanceImage",
                FieldName = "AttendanceImage",
                Visible = true,
                UnboundType = DevExpress.Data.UnboundColumnType.Object,
                VisibleIndex = 0,
                Width = 25,
                MaxWidth = 25,
                ToolTip = "IVR Attendance",
                ColumnEdit = pictureEdit
            });
        }
    }  
     

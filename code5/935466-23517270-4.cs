    protected void Page_Load(object sender, EventArgs e)
    {
        //RestoreForm();
        if (IsPostBack && FileUpload.HasFile)
        {
            AddRow(FileUpload.PostedFile.FileName);
        }
        else
        {
            AddDataTableToSession();
        }
        FilesGridView.RowDeleting += new GridViewDeleteEventHandler(RemoveFileFromTable);
        FilesGridView.RowDataBound += KBFilesGridView_RowDataBound;
    }

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
        KBFilesGridView.RowDeleting += new GridViewDeleteEventHandler(RemoveFileFromTable);
        KBFilesGridView.RowDataBound += KBFilesGridView_RowDataBound;
    }

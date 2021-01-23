     private void GetNotesList(int Id, int Page)
        {
            DataAccess.LexCodeNode LexCodeNode = new DataAccess.LexCodeNode();
            LexCodeNode.GetNotesList(Id);
            BindGrid(DgNoteLst, LexCodeNode.DefaultView);
        }

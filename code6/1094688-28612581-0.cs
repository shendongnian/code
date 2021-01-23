    public void getStartPoint(Transaction oTr, ObjectId oId)
    {
        try {
            Line oLn = (Line)oTr.GetObject(oId, OpenMode.ForRead);
    
            if (oLn != null) {
                Interaction.MsgBox(oLn.StartPoint.X.ToString);
            }
    
        } catch (System.Exception ex) {
            Interaction.MsgBox(ex.StackTrace, (MsgBoxStyle)MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, ex.Message);
        }
    }

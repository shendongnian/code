    Dim ContentPlaceHolder As ContentPlaceHolder
    Dim gv As GridView
    ContentPlaceHolder = CType(Master.FindControl("GridViewPlaceHolder"), ContentPlaceHolder)
    If Not ContentPlaceHolder Is Nothing Then
        gv = CType(ContentPlaceHolder.FindControl("GridView1"), GridView)
          If Not gv Is Nothing Then
            Dim es As EntityDataSource = EntityDataSource1
            gv.DataSource = es
            gv.DataBind()
        End If
    End If

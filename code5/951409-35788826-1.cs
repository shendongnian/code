      // javascript Function
        <script type="text/javascript">
       $(document).ready(function () {
      $('#ddlReport').removeClass('required');
       $('.sort').click(function () {
        $('#hdnColumnName').val($(this).text());
        $('#hdnColumnOrder').val($(this).attr('class'));
        $(this).toggleClass("desc asc");
        $("#lnkSort").click();
         });
      }  );
      // Bind repeater
         DataTable dt = objReport.GetCustomRecord();
       fn = new List<string>();
       for (int i = 0; i < dt.Columns.Count; i++)
      {
        if (dt.Columns[i].ColumnName != "Maxcount" )
        {
            fn.Add(dt.Columns[i].ColumnName);
        }
    }
    Repeater1.DataSource = dt;
    Repeater1.DataBind();
          protected void Repeater1_databinding(object sender,   RepeaterItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Header)
     {
       if (e.Item.FindControl("literalHeader") != null)
       {
              StringBuilder sb = new StringBuilder();
             Literal li = e.Item.FindControl("literalHeader") as Literal;
             fieldName().ForEach(delegate(string fn)
               {
               if (hdnColumnName.Value != fn.ToString())
                 {
                    sb.Append("<th width=\"10%\"> <a id=\"btnCustomerName\" class=\"sort desc\" onclick=\"btnSorts_onclick()\" style=\"cursor:pointer;text-decoration: none !important;\" >"
                    + fn.ToString() + "</a></th>");
                 }
                else
                {
                   if (hdnColumnOrder.Value == "sort asc")
                    sb.Append("<th width=\"10%\"> <a id=\"btnCustomerName\" class=\"sort desc\"  onclick=\"btnSorts_onclick()\" style=\"cursor:pointer;text-decoration: none !important;\" >"
                   + fn.ToString() + "</a></th>");
                else
                    sb.Append("<th width=\"10%\"> <a id=\"btnCustomerName\" class=\"sort asc\" onclick=\"btnSorts_onclick()\" style=\"cursor:pointer;text-decoration: none !important;\">"
                                               + fn.ToString() + "</a></th>");
            }
        });
        li.Text = sb.ToString();
       }
     }
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
     {
     if (e.Item.FindControl("literals") != null)
     {
        DataRowView drv = (DataRowView)e.Item.DataItem;
        Literal li = e.Item.FindControl("literals") as Literal;
        StringBuilder sb = new StringBuilder();
        fieldName().ForEach(delegate(string fn)
        {
            sb.Append("<td>" + drv[fn.ToString()] + "</td>");
        });
        li.Text = sb.ToString();
     }
      }
     }

    protected void Buttonexcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment;filename=dados.xls");
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hWriter = new HtmlTextWriter(sWriter);
            GridView1.RenderControl(hWriter);
            string style = @"<style> .textmode {mso-number-format:General} </style>";
            Response.Output.Write(sWriter.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
